using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class economiaJugador : MonoBehaviour
{
    public int cantidadMonedas;
    public TextMeshProUGUI cantMonedas; // Asigna aqu� el texto de UI que muestra las monedas
    public float tiempoJuego = 0f; // Controla el tiempo para generar monedas autom�ticamente

    void Start()
    {
        cantidadMonedas = 0;
        ActualizarUI();
    }

    void Update()
    {
        // Genera monedas autom�ticamente cada segundo
        tiempoJuego += Time.deltaTime;
        if (tiempoJuego >= 1f)
        {
            cantidadMonedas += 1;
            tiempoJuego = 0f;
            ActualizarUI();
        }
    }

    public void RecibirMonedas(int cantidadRecibida)
    {
        cantidadMonedas += cantidadRecibida;
        Debug.Log("Monedas actuales: " + cantidadMonedas);
        ActualizarUI();
    }

    private void ActualizarUI()
    {
        // Actualiza el texto de la UI con la cantidad actual de monedas
        if (cantMonedas != null)
        {
            cantMonedas.SetText(cantidadMonedas.ToString());
        }
        else
        {
            Debug.LogWarning("El campo 'cantMonedas' no est� asignado en el Inspector.");
        }
    }
}
