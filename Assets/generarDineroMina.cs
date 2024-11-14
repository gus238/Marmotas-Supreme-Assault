using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarDineroMina : MonoBehaviour
{
    public int tiempoPorPlata;  // Este valor puede ser un entero (en segundos).
    public int cantDineroPorTick;  // Este valor también debe ser un entero.
    private float rateGeneracionDinero = 0f;  // Mantén este valor como float para llevar el conteo en tiempo real.
    public GameObject player;

    void Update()
    {
        rateGeneracionDinero += Time.deltaTime;

        // Asegúrate de comparar correctamente los valores
        if (rateGeneracionDinero >= tiempoPorPlata)
        {
            // Aquí se hace la conversión explícita de float a int si es necesario.
            player.GetComponent<economiaJugador>().RecibirMonedas(cantDineroPorTick);

            // Reiniciar la tasa de generación
            rateGeneracionDinero = 0f;
        }
    }
}
