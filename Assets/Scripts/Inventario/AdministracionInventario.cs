using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministracionInventario : MonoBehaviour
{
    //Toma el canva de inventario y el estado del canva de cultivos
    public GameObject MenuInventario;
    public bool ActivacionInventario;
    public bool InterfazCultivos;
    public AdministracionCultivos adminCultivos;

    //Encuentra el componente AdministracionCultivos en el CanvasCultivos
    void Start()
    {
        
        GameObject canvasCultivos = GameObject.Find("CanvasCultivos");
        if (canvasCultivos != null)
        {
            adminCultivos = canvasCultivos.GetComponent<AdministracionCultivos>();
        }
    }

    //Si se aprieta tab y el canva de inventario y cultivos estan desactivados pausa el tiempo y abre el inventario, activa el cursor
    //Sino si el inventario esta activado al apretar tab, desactiva el inventario, reanuda el tiempo y desactiva el cursor
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

    //Al apretar cultivos en el inventario desactiva el inventario y encuentra el canva de cultivos y lo activa
    public void ActivarCultivos()
    {
        //Desactiva el menú de inventario
        MenuInventario.SetActive(false);
        ActivacionInventario = false;

        //Encuentra el CanvasCultivos y activa el menú
        GameObject padre = GameObject.Find("CanvasCultivos");
        if (padre != null)
        {
            Transform hijoTransform = padre.transform.Find("MenuCultivos");
            if (hijoTransform != null)
            {
                GameObject hijo = hijoTransform.gameObject;
                hijo.SetActive(true); //Activa el menú de cultivos

                //Actualiza el estado de los booleanos en ambos scripts
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
