using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valorMoneda = 1;  // Cuántas monedas da esta moneda
    public GameObject jugador;  // El objeto del jugador, que puedes arrastrar desde el Inspector

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona es el jugador asignado
        if (other.gameObject == jugador)
        {
            economiaJugador economia = jugador.GetComponent<economiaJugador>();
            if (economia != null)
            {
                economia.RecibirMonedas(valorMoneda);  // Suma las monedas al jugador
                Destroy(gameObject);  // Destruye la moneda después de que el jugador la recoge
            }
        }
    }
}
