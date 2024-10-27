using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministracionInventario : MonoBehaviour
{
    public GameObject MenuInventario;
    public bool ActivacionInventario;
    public bool InterfazCultivos;
    public AdministracionCultivos adminCultivos;

    void Start()
    {
        // Encuentra el componente AdministracionCultivos en el CanvasCultivos
        GameObject canvasCultivos = GameObject.Find("CanvasCultivos");
        if (canvasCultivos != null)
        {
            adminCultivos = canvasCultivos.GetComponent<AdministracionCultivos>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !ActivacionInventario && !InterfazCultivos)
        {
            Time.timeScale = 0;
            MenuInventario.SetActive(true);
            ActivacionInventario = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && ActivacionInventario)
        {
            Time.timeScale = 1;
            MenuInventario.SetActive(false);
            ActivacionInventario = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ActivarCultivos()
    {
        // Desactiva el menú de inventario
        MenuInventario.SetActive(false);
        ActivacionInventario = false;

        // Encuentra el CanvasCultivos y activa el menú
        GameObject padre = GameObject.Find("CanvasCultivos");
        if (padre != null)
        {
            Transform hijoTransform = padre.transform.Find("MenuCultivos");
            if (hijoTransform != null)
            {
                GameObject hijo = hijoTransform.gameObject;
                hijo.SetActive(true); // Activa el menú de cultivos

                // Actualiza el estado en ambos scripts
                InterfazCultivos = true;
                if (adminCultivos != null)
                {
                    adminCultivos.InterfazCultivos = true;
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
