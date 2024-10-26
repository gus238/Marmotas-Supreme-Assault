using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuOpciones : MonoBehaviour
{
    public void cargarJuego(string nombre)
    {
        SceneManager.LoadScene(nombre);

    }
    public void salir() { Application.Quit(); Debug.Log("Saliendo del juego"); }
}
