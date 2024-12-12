using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuOpciones : MonoBehaviour
{
    public void cargarJuego(string nombre)
    {
        SceneManager.LoadScene(nombre);
        Time.timeScale = 1;
        //carga la escena del juego y activa el tiempo
    }
    public void salir() { Application.Quit(); Debug.Log("Saliendo del juego"); } //sale del juego al presionar salir
}
