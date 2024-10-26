using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public GameObject CamaraPersonaje;
    public Camera CamaraPausa;

    private bool Pausa = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa = !Pausa;
            ObjetoMenuPausa.SetActive(Pausa);
            CamaraPersonaje.gameObject.SetActive(!Pausa);
            CamaraPausa.gameObject.SetActive(Pausa);

            Time.timeScale = Pausa ? 0 : 1;
        }
    }

    public void Reanudar()
    {
        Pausa = false;
        ObjetoMenuPausa.SetActive(false);
        CamaraPersonaje.gameObject.SetActive(true);
        CamaraPausa.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void VolverMenu(string NombreMenu)
    {
        Time.timeScale = 1; // Reactivar el tiempo antes de cargar la escena
        SceneManager.LoadScene(NombreMenu);
    }
}
