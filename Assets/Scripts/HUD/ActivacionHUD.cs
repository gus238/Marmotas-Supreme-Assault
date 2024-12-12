using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionHUD : MonoBehaviour
{
    public GameObject HudObjeto;
    
    void Start()
    {
        HudObjeto.SetActive(true); //activa el objeto Hud para mostrarle al player
    }

    
    
}
