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
            Time.timeScale = 0;
            MenuInventario.SetActive(true);
            ActivacionInventario = true;
        }

        else if (Input.GetKeyDown(KeyCode.Tab) && ActivacionInventario)
        {
            Time.timeScale = 1;
            MenuInventario.SetActive(false);    
            ActivacionInventario = false;
        }
    }

    public void ActivacionInterfaz(string NombreInterfaz)
    {
        MenuInventario.SetActive(false);
        ActivacionInventario = false;
        GameObject Interfaz = GameObject.Find(NombreInterfaz);
        if (Interfaz != null)
        {
            Interfaz.SetActive(true);
        }

    }
    public void ActivarCultivos()
    {
        ActivacionInterfaz("MenuCultivos"); // Asegúrate de usar el nombre correcto
    }

    public void ActivarTienda()
    {
        ActivacionInterfaz("MenuTienda"); // Asegúrate de usar el nombre correcto
    }
}
