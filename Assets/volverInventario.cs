using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volverInventario : MonoBehaviour
{
    public GameObject inventario;
    public GameObject panelArmas;
    public GameObject panelConsumibles;
    public GameObject panelHabilidades;
    public void PasarInventario()
    {
        inventario.SetActive(true);
        panelArmas.SetActive(false);
        panelConsumibles.SetActive(false);
        panelHabilidades.SetActive(false);
    }
}
