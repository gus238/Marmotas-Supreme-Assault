using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scriptMina : MonoBehaviour
{
    public GameObject mina;
    public GameObject hudMina;
    public GameObject player;
    public GameObject monedaPrefab; // Prefab de la moneda que se generar�
    public int coste;
    private bool construido;
    private economiaJugador monedas;
    public TextMeshProUGUI costeTexto;

    public float intervaloGeneracionMonedas = 5f; // Intervalo en segundos para generar monedas f�sicas
    private float tiempoGeneracionMonedas;

    public int tiempoPorPlata = 10; // Intervalo en segundos para a�adir dinero directo al jugador
    public int cantDineroPorTick = 5; // Cantidad de dinero directo por intervalo
    private float tiempoGeneracionDinero = 0f;

    void Start()
    {
        construido = false;
        hudMina.SetActive(false);
        mina.SetActive(false);
        monedas = player.GetComponent<economiaJugador>();
        costeTexto.SetText("Coste: " + coste);
        tiempoGeneracionMonedas = intervaloGeneracionMonedas; // Inicializa el temporizador para las monedas f�sicas
    }

    void OnTriggerStay(Collider objeto)
    {
        if (objeto.CompareTag("Player"))
        {
            hudMina.SetActive(true);

            if (Input.GetKey(KeyCode.E) && monedas.cantidadMonedas >= coste && !construido)
            {
                mina.SetActive(true);
                construido = true;
                monedas.RecibirMonedas(-coste); // Resta el coste al jugador
            }
        }
    }

    private void OnTriggerExit(Collider objeto)
    {
        hudMina.SetActive(false);
    }

    void Update()
    {
        if (construido)
        {
            // Generaci�n de monedas f�sicas
            tiempoGeneracionMonedas -= Time.deltaTime;
            if (tiempoGeneracionMonedas <= 0f)
            {
                GenerarMonedaFisica();
                tiempoGeneracionMonedas = intervaloGeneracionMonedas; // Reinicia el temporizador
            }

            // Generaci�n de dinero directo al jugador
            tiempoGeneracionDinero += Time.deltaTime;
            if (tiempoGeneracionDinero >= tiempoPorPlata)
            {
                monedas.RecibirMonedas(cantDineroPorTick);
                tiempoGeneracionDinero = 0f; // Reinicia el temporizador
            }
        }
    }

    void GenerarMonedaFisica()
    {
        // Genera una moneda f�sica en la posici�n de la mina
        Instantiate(monedaPrefab, mina.transform.position + Vector3.up, Quaternion.identity);
    }
}
