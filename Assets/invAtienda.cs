using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invAtienda : MonoBehaviour
{
    //Variables que toman los GameObjects que se tienen que cerrar y abrir
    public GameObject tienda;
    public GameObject inventario;

    //Funcion que se llama al apretar tienda desde el inventario
    public void PasarTienda()
    {
        tienda.SetActive(true);
        inventario.SetActive(false);
    }
}
