using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volverInventario : MonoBehaviour
{
    //Variables que toman los gameobjects que se tienen que cerrar y abrir cuando apretas volver en cualquier pestaña de la tienda
    public GameObject inventario;
    public GameObject panelArmas;
    public GameObject panelConsumibles;
    public GameObject panelHabilidades;

    //Funcion que se llama al tocar el boton volver en cualquier pestaña de la tienda
    public void PasarInventario()
    {
        inventario.SetActive(true);
        panelArmas.SetActive(false);
        panelConsumibles.SetActive(false);
        panelHabilidades.SetActive(false);
    }
}
