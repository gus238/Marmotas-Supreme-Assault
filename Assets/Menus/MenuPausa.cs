using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    private bool Pausa = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa = !Pausa; 
            ObjetoMenuPausa.SetActive(Pausa);

            if (Pausa)
            {
                Time.timeScale = 0; 
            }
            else
            {
                Time.timeScale = 1; 
            }
        }
    }

   
    public void Reanudar()
    {
        Pausa = false;
        ObjetoMenuPausa.SetActive(false);
        Time.timeScale = 1;
    }
    public void VolerMenu(string NombreMenu)
    {
        SceneManager.LoadScene(NombreMenu);
    }
}
