using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valorMoneda;
    public GameObject jugador;
    public AudioSource sourceSonido;
    public AudioClip ruiditoMoneda;
    economiaJugador monedas;

    void Start()
    {
        monedas = jugador.GetComponent<economiaJugador>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            monedas.RecibirMonedas(valorMoneda);  
            sourceSonido.PlayOneShot(ruiditoMoneda);
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject);
        }
    }
}
