using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministracionCultivos : MonoBehaviour
{
    public GameObject MenuCultivos;
    public bool InterfazCultivos;
    public AdministracionInventario adminInventario;

    void Start()
    {
        // Encuentra el componente AdministracionInventario en el CanvasInventario
        GameObject canvasInventario = GameObject.Find("CanvasInventario");
        if (canvasInventario != null)
        {
            adminInventario = canvasInventario.GetComponent<AdministracionInventario>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Time.timeScale = 1;
            MenuCultivos.SetActive(false);
            InterfazCultivos = false;

            // Actualiza el estado en AdministracionInventario
            if (adminInventario != null)
            {
                adminInventario.InterfazCultivos = false;
            }
        }
    }

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
                hijo.SetActive(true); // Activa el inventario

                // Actualiza el estado en AdministracionInventario
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

