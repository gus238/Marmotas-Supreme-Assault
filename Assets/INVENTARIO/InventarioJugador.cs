using System.Collections.Generic;
using UnityEngine;

public class InventarioJugador : MonoBehaviour
{
    public GameObject[] Armas = new GameObject[4]; // Inventario con capacidad de 4 armas
    public GameObject ArmaEquipada; // Arma actualmente equipada
    public Transform ManoJugador; // Donde se equiparán las armas
    public Transform PuntoDrop; // Lugar donde se soltarán las armas

    private int indiceArma = -1; // Índice del arma equipada

    void Update()
    {
        // Cambiar entre armas con las teclas 1, 2, 3 y 4
        if (Input.GetKeyDown(KeyCode.Alpha1)) CambiarArma(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) CambiarArma(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) CambiarArma(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) CambiarArma(3);

        // Soltar arma con 'G'
        if (Input.GetKeyDown(KeyCode.G)) SoltarArma();
    }

    public void RecogerArma(GameObject nuevaArma)
    {
        for (int i = 0; i < Armas.Length; i++)
        {
            if (Armas[i] == null) // Encuentra un espacio vacío en el inventario
            {
                Armas[i] = nuevaArma;
                EquiparArma(i);
                nuevaArma.SetActive(false); // Oculta el arma en el mundo
                return;
            }
        }
        Debug.Log("Inventario lleno");
    }

    private void CambiarArma(int indice)
    {
        if (indice >= 0 && indice < Armas.Length && Armas[indice] != null)
        {
            EquiparArma(indice);
        }
    }

    private void EquiparArma(int indice)
    {
        if (ArmaEquipada != null)
        {
            ArmaEquipada.SetActive(false);
        }

        ArmaEquipada = Armas[indice];
        ArmaEquipada.SetActive(true);
        ArmaEquipada.transform.SetParent(ManoJugador); // La arma se coloca en la mano del jugador
        ArmaEquipada.transform.localPosition = Vector3.zero;
        ArmaEquipada.transform.localRotation = Quaternion.identity;
        indiceArma = indice;
    }

    private void SoltarArma()
    {
        if (ArmaEquipada != null)
        {
            ArmaEquipada.SetActive(true);
            ArmaEquipada.transform.SetParent(null); // Desvincula el arma de la mano
            ArmaEquipada.transform.position = PuntoDrop.position; // Aparece en el punto de drop
            Armas[indiceArma] = null;
            ArmaEquipada = null;
            indiceArma = -1;
        }
    }
}
