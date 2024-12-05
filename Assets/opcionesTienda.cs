using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opcionesTienda : MonoBehaviour
{
    public GameObject armas;
    public GameObject consumibles;
    public GameObject habilidades;

    public void HabilitarArmas()
    {
        armas.SetActive(true);
        consumibles.SetActive(false);
        habilidades.SetActive(false);
    }
    public void HabilitarConsumibles() 
    {
        armas.SetActive(false);
        consumibles.SetActive(true);
        habilidades.SetActive(false);
    }
    public void HabilitarHabilidades()
    {
        armas.SetActive(false);
        consumibles.SetActive(false);
        habilidades.SetActive(true);
    }
}
