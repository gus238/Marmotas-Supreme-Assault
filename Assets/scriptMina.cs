using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scriptMina : MonoBehaviour
{
    public GameObject mina;
    public GameObject hudMina;
    public GameObject player;
    public int coste;
    private bool construido;
    economiaJugador monedas;
    int dinero;
    public TextMeshProUGUI costeTexto;
    void Start()
    {
        construido = false;
        hudMina.SetActive(false);
        mina.SetActive(false);
        monedas = player.GetComponent<economiaJugador>();
        costeTexto.SetText("Coste: " + coste);
    }

    void OnTriggerStay(Collider objeto)
    {

        if (objeto.tag == "Player")
        {
            hudMina.SetActive(true);

            if (Input.GetKey(KeyCode.E) && dinero >= coste && !construido)
            {
                mina.SetActive(true);
                construido = true;
                player.GetComponent<economiaJugador>().RecibirMonedas(-coste);

            }
        }
    }

    private void OnTriggerExit(Collider objeto)
    {
        hudMina.SetActive(false);
    }

    void Update()
    {
        dinero = monedas.cantidadMonedas;
    }

}
