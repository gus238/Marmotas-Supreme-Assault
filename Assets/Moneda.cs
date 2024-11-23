using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valorMoneda = 1;  // Cu�ntas monedas da esta moneda
    public GameObject jugador;  // El objeto del jugador, que puedes arrastrar desde el Inspector
    public AudioSource sourceSonido;
    public AudioClip ruiditoMoneda;
    economiaJugador monedas;

    void Start()
    {
        monedas = jugador.GetComponent<economiaJugador>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona es el jugador asignado
        if (other.CompareTag("Player"))
        {
            monedas.RecibirMonedas(valorMoneda);  // Suma las monedas al jugador
            sourceSonido.PlayOneShot(ruiditoMoneda);
            Destroy(gameObject);  // Destruye la moneda despu�s de que el jugador la recoge
        }
    }
}
