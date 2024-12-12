using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invAtienda : MonoBehaviour
{
    public GameObject tienda;
    public GameObject inventario;
    public void PasarTienda()
    {
        tienda.SetActive(true);
        inventario.SetActive(false);
    }
}
