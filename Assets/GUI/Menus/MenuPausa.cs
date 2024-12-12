using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    private bool Pausa; //booleano que se vuelve true si se pone en pausa

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //si se presiona esc
        {
            Pausa = !Pausa;
            ObjetoMenuPausa.SetActive(Pausa); //se activa la pantalla de pausa (canva)
            Cursor.lockState = CursorLockMode.None; // habilita el uso del cursor, ya que si no, no es posible verlo en la pantalla
            Cursor.visible = true; //activa el cursor
            Time.timeScale = 0;
        }
    }

    public void Reanudar()
    {
        Pausa = false;
        ObjetoMenuPausa.SetActive(false); //se desactiva el canva de pausa
        Cursor.lockState = CursorLockMode.Locked; //deshabilita el uso del cursor
        Cursor.visible = false; //desactiva el cursor
        Time.timeScale = 1;
    }

    public void VolverMenu(string NombreMenu)
    {
        Time.timeScale = 1; // devuelve el tiempo al juego 
        SceneManager.LoadScene(NombreMenu); //cambia de escena
    }
}
