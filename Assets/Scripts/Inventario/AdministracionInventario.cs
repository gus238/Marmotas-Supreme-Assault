using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//funcionalidad del canvas inventario, apretar tab para que se abra, apretar reaanudar para que se cierre, abrir los cultivos
public class AdministracionInventario : MonoBehaviour
{
    //Toma el canva de inventario y el estado del canva de cultivos
    public GameObject MenuInventario; // canva inventario
    public bool ActivacionInventario;
    public bool InterfazCultivos;
    public AdministracionCultivos adminCultivos;
    public GameObject MenuCultivo;

    //Encuentra el componente AdministracionCultivos en el CanvasCultivos
    void Start()
    {

        MenuCultivo.SetActive(false);
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
    public void DesdeInvHastaCultivos()
    {
        MenuInventario.SetActive(false);
        MenuCultivo.SetActive(true);

    }

    //Al apretar cultivos en el inventario desactiva el inventario y encuentra el canva de cultivos y lo activa
    
}
