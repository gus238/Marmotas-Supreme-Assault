using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarDineroMina : MonoBehaviour
{
    public int tiempoPorPlata;
    public int cantDineroPorTick;
    private float rateGeneracionDinero = 0f;
    public GameObject player;

    void Update()
    {
        rateGeneracionDinero += Time.deltaTime;
        if (rateGeneracionDinero >= tiempoPorPlata)
        {
            player.GetComponent<economiaJugador>().RecibirMonedas(cantDineroPorTick);
            rateGeneracionDinero = 0f;
        }
    }

}
