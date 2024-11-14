using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scriptCultivo : MonoBehaviour
{
    public GameObject cultivo; // Objeto que representa el cultivo
    public GameObject hudCultivo; // HUD que muestra información del cultivo
    public GameObject player; // Referencia al jugador
    public int coste; // Costo en monedas para activar el cultivo
    private bool activado; // Indica si el cultivo está activado o no
    economiaJugador monedas; // Componente de economía del jugador
    int dinero; // Dinero actual del jugador
    public TextMeshProUGUI costeTexto; // Texto que muestra el coste del cultivo en el HUD

    void Start()
    {
        activado = false;
        hudCultivo.SetActive(false); // HUD oculto inicialmente
        cultivo.SetActive(false); // Cultivo inactivo al inicio
        monedas = player.GetComponent<economiaJugador>();
        costeTexto.SetText("Coste: " + coste); // Muestra el coste en el HUD
    }

    void Update()
    {
        dinero = monedas.cantidadMonedas; // Actualiza la cantidad de dinero del jugador en cada cuadro
    }

    // Método que se llama desde un botón en el inventario para activar el cultivo
    public void ActivarCultivo()
    {
        if (dinero >= coste && !activado)
        {
            cultivo.SetActive(true); // Activa el cultivo en el juego
            activado = true; // Marca el cultivo como activado
            monedas.RecibirMonedas(-coste); // Deduce el coste del dinero del jugador
            hudCultivo.SetActive(true); // Opcional: mostrar HUD cuando el cultivo esté activado
        }
        else
        {
            Debug.Log("No tienes suficiente dinero o el cultivo ya está activado.");
        }
    }
}
