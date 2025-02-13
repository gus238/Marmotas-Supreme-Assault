using UnityEngine;

public class ArmaEnElMundo : MonoBehaviour
{
    public WeaponInventory weaponInventory;  // Inventario de armas del jugador
    public GameObject armaCercana;          // Referencia al arma que el jugador tiene cerca
    public float rangoDetectarArma = 2f;    // Rango en el que el jugador puede recoger el arma
    private Collider armaCollider;

    void Update()
    {
        // Detectar el arma más cercana
        DetectarArmaCercana();

        // Si el jugador presiona 'F' y hay un arma cercana, se recoge el arma
        if (armaCercana != null && Input.GetKeyDown(KeyCode.F))
        {
            AgarrarArma();
        }
    }

    // Detectar el arma más cercana en el rango definido
    private void DetectarArmaCercana()
    {
        // Usamos un método de detección de colisión en el rango especificado
        Collider[] colisiones = Physics.OverlapSphere(transform.position, rangoDetectarArma);
        foreach (Collider col in colisiones)
        {
            if (col.CompareTag("Arma"))
            {
                armaCercana = col.gameObject;
                return; // Sale cuando encuentra el primer arma
            }
        }

        armaCercana = null; // Si no se encuentra ninguna arma cercana
    }

    // Método para agarrar el arma y agregarla al inventario
    private void AgarrarArma()
    {
        if (armaCercana != null)
        {
            // Crea una nueva instancia de Weapon usando el GameObject del arma
            Weapon arma = new Weapon(armaCercana);

            // Agrega el arma al inventario
            weaponInventory.AgregarArma(arma);

            // Destruye el GameObject del arma en el mundo
            Destroy(armaCercana);

            // Limpiamos la referencia de armaCercana
            armaCercana = null;
        }
    }
}
