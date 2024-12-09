using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invAtienda : MonoBehaviour
{
    public GameObject tienda;
    public void PasarTienda()
    {
        tienda.SetActive(true);
        gameObject.SetActive(false);
    }
}
