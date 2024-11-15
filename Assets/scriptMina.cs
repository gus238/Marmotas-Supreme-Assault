using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scriptMina : MonoBehaviour
{
    public GameObject mina;
    public GameObject hudMina;
    public GameObject player;
    public GameObject monedaPrefab; // Prefab de la moneda f�sica que se generar�
    public int coste;
    public float intervaloGeneracionMonedas = 5f; // Intervalo en segundos para generar monedas
    private bool construido;
    private float tiempoGeneracion;
    economiaJugador monedas;
    int dinero;
    public TextMeshProUGUI costeTexto;
    public GameObject lugarSpawnMonedas;

    void Start()
    {
        construido = false;
        hudMina.SetActive(false);
        mina.SetActive(false);
        monedas = player.GetComponent<economiaJugador>();
        costeTexto.SetText("Coste: " + coste);
        tiempoGeneracion = 0f; // Inicializa el temporizador en 0
    }

    void Update()
    {
        dinero = monedas.cantidadMonedas;

        // Genera monedas en intervalos despu�s de construir la mina
        if (construido)
        {
            tiempoGeneracion += Time.deltaTime;
            if (tiempoGeneracion >= intervaloGeneracionMonedas)
            {
                GenerarMoneda();
                tiempoGeneracion = 0f; // Reinicia el temporizador
            }
        }
    }

    void OnTriggerStay(Collider objeto)
    {
        if (objeto.CompareTag("Player"))
        {
            hudMina.SetActive(true);

            if (Input.GetKey(KeyCode.E) && dinero >= coste && !construido)
            {
                mina.SetActive(true);
                construido = true;
                monedas.RecibirMonedas(-coste);
            }
        }
    }

    private void OnTriggerExit(Collider objeto)
    {
        hudMina.SetActive(false);
    }

    // M�todo para generar una moneda en la posici�n de la mina
    void GenerarMoneda()
    {
        Instantiate(monedaPrefab, lugarSpawnMonedas.transform.position + Vector3.up, Quaternion.identity);
    }
}