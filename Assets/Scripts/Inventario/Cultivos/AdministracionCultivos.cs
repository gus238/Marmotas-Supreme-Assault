using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministracionCultivos : MonoBehaviour
{
    //Toma el canva que tiene el menu de cultivos y el estado del canva del inventario
    public GameObject MenuCultivos;
    public bool InterfazCultivos;
    public AdministracionInventario adminInventario;

    //Encuentra el canvas del inventario y toma el script de administracion inventario de este gameobject
    void Start()
    {
        // Encuentra el componente AdministracionInventario en el CanvasInventario
        GameObject canvasInventario = GameObject.Find("CanvasInventario");
        if (canvasInventario != null)
        {
            adminInventario = canvasInventario.GetComponent<AdministracionInventario>();
        }
    }

    //Si se aprieta Tab sale del canva cultivos y reanuda el tiempo, ademas de darle el valor de que cultivo esta desactivado a administracionInventario
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Time.timeScale = 1;
            MenuCultivos.SetActive(false);
            InterfazCultivos = false;

            if (adminInventario != null)
            {
                adminInventario.InterfazCultivos = false;
            }
        }
    }

    //Al apretar volver en el canva cultivos desactiva a este y vuelve al inventario que encuentra en la escena
    public void VolverMenu()
    {
        // Desactiva el menú de cultivos
        MenuCultivos.SetActive(false);
        InterfazCultivos = false;

        // Encuentra el menú de inventario y lo activa
        GameObject padre = GameObject.Find("CanvasInventario");
        if (padre != null)
        {
            Transform hijoTransform = padre.transform.Find("MenuInventario");
            if (hijoTransform != null)
            {
                GameObject hijo = hijoTransform.gameObject;
                hijo.SetActive(true);

                if (adminInventario != null)
                {
                    adminInventario.InterfazCultivos = false;
                }
            }
            else
            {
                Debug.LogWarning("Hijo no encontrado");
            }
        }
        else
        {
            Debug.LogWarning("Padre no encontrado");
        }
    }
}

