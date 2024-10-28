using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    private bool Pausa;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa = !Pausa;
            ObjetoMenuPausa.SetActive(Pausa);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }

    public void Reanudar()
    {
        Pausa = false;
        ObjetoMenuPausa.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void VolverMenu(string NombreMenu)
    {
        Time.timeScale = 1; // Reactivar el tiempo antes de cargar la escena
        SceneManager.LoadScene(NombreMenu);
    }
}
