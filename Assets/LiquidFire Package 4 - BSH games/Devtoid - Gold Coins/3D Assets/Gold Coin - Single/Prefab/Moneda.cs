using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valorMoneda = 5; // Cantidad de monedas que esta moneda otorga al jugador

    private void OnTriggerEnter(Collider other)
    {
        // Detecta si el objeto que colisiona es el jugador
        if (other.CompareTag("Player"))
        {
            economiaJugador economia = other.GetComponent<economiaJugador>();
            if (economia != null)
            {
                economia.RecibirMonedas(valorMoneda); // Agrega las monedas al jugador
                Destroy(gameObject); // Destruye la moneda después de recogerla
            }
        }
    }
}
