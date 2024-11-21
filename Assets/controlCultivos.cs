using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCultivos : MonoBehaviour
{
    public GameObject player;
    economiaJugador dinero;
    int dineroActual;
    public GameObject cultivo;
    public int costeCompra;
    
    void Start()
    {
        cultivo.SetActive(false);
        dinero = player.GetComponent<economiaJugador>();
    }


    void Update()
    {
        dineroActual = dinero.cantidadMonedas;
    }

    public void ActivarCultivo()
    {

        if (dineroActual >= costeCompra)
        {
            dinero.RecibirMonedas(-costeCompra);
            cultivo.SetActive(true);
            Debug.Log("el cultivo fue plantado");
        }
    }

    private void CrecimientoDeCultivo()
    {

    }
}
