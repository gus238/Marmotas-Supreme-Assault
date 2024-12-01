using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerCultivo : MonoBehaviour
{
    public int valorCultivo;
    public GameObject player;
    public GameObject parcela;
    public GameObject imagenCrecido;

    economiaJugador dinero;

    void Start()
    {
        dinero = player.GetComponent<economiaJugador>();
    }

    public void DarDinero()
    {
        Debug.Log("Cultivo cosechado, añadiendo dinero.");
        dinero.cantidadMonedas += valorCultivo;
        imagenCrecido.SetActive(false);
    }
}

