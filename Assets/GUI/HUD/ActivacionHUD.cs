using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionHUD : MonoBehaviour
{
    public GameObject HudObjeto;
    
    void Start()
    {
        HudObjeto.SetActive(true);
    }

    
    void Update()
    {
        
    }
}
