using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cosechaCultivo : MonoBehaviour
{
    public int valorCultivo;
    public GameObject player;
    economiaJugador dinero;
    int dineroActual;
    void Start()
    {
        dinero = player.GetComponent<economiaJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        dineroActual = dinero.cantidadMonedas;
    }

    public void DarDinero()
    {
        Debug.Log("DOY DINERO PORQUE SOY UN CULTIVO");
        dineroActual += valorCultivo;
    }

}
