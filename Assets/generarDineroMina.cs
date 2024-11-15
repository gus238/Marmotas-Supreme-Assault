using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarDineroMina : MonoBehaviour
{
    public int tiempoPorPlata;  // Este valor puede ser un entero (en segundos).
    public int cantDineroPorTick;  // Este valor tambi�n debe ser un entero.
    private float rateGeneracionDinero = 0f;  // Mant�n este valor como float para llevar el conteo en tiempo real.
    public GameObject player;

    void Update()
    {
        rateGeneracionDinero += Time.deltaTime;

        // Aseg�rate de comparar correctamente los valores
        if (rateGeneracionDinero >= tiempoPorPlata)
        {
            // Aqu� se hace la conversi�n expl�cita de float a int si es necesario.
            player.GetComponent<economiaJugador>().RecibirMonedas(cantDineroPorTick);

            // Reiniciar la tasa de generaci�n
            rateGeneracionDinero = 0f;
        }
    }
}
