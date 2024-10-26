using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministracionInventario : MonoBehaviour
{
    public GameObject MenuInventario;
    private bool ActivacionInventario;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !ActivacionInventario) 
        {   
            MenuInventario.SetActive(true);
            ActivacionInventario = true;
        }

        else if (Input.GetKeyDown(KeyCode.Tab) && ActivacionInventario)
        {
            MenuInventario.SetActive(false);    
            ActivacionInventario = false;
        }
    }
}
