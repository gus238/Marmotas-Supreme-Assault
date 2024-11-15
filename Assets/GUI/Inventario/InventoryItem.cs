// File name: InventoryItem.cs

using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    [Header("Propiedades del Arma")]
    public string itemName;
    public Sprite icon;
    public bool isStackable;
    public int da�o;
    public float fireRate;
    public float rango;
    public float tiempoRecarga;
    public float tiempoEntreRafaga;
    public int tama�oCargador;
    public int tama�oRafaga;
    public bool mantenerApretado;
    public AudioClip disparoSonido;
    public AudioClip recargaSonido;
    public AnimationClip shootAnimation;

    [Header("Estado de Munici�n")]
    public int balasRestantes;
    public int balasDisparadas;

    [Header("Referencias del Arma")]
    public GameObject modeloArma;
    public Transform puntoDisparo;

    public void Disparar(Camera fpsCam, AudioSource audioSource)
    {
        if (balasRestantes > 0)
        {
            balasRestantes--;
            Debug.Log(itemName + " disparado! Balas restantes: " + balasRestantes);

            // Reproducir sonido de disparo
            if (disparoSonido != null && audioSource != null)
            {
                audioSource.PlayOneShot(disparoSonido);
            }

            // L�gica para raycast del disparo
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, rango))
            {
                Debug.Log("Impacto en: " + hit.collider.name);
                VidaEnemigo vidaEnemigo = hit.collider.GetComponent<VidaEnemigo>();
                if (vidaEnemigo != null)
                {
                    vidaEnemigo.TakeDamage(da�o);
                }
            }
        }
        else
        {
            Debug.Log(itemName + " sin munici�n!");
        }
    }

    public void Recargar(AudioSource audioSource)
    {
        Debug.Log("Recargando " + itemName);
        balasRestantes = tama�oCargador;

        // Reproducir sonido de recarga
        if (recargaSonido != null && audioSource != null)
        {
            audioSource.PlayOneShot(recargaSonido);
        }
    }
}
