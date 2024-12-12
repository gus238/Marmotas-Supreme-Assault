using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicaEntreEscenas : MonoBehaviour
{
    //Se asigna la escena, el nombre de la escena y la instancia(escena) en la que estamos parados
    private static musicaEntreEscenas instance;
    public AudioSource musicaMenu;
    public string escenaJuego;

    //Verifica que solo haya una instancia del gameobject y no lo destruye al cambiar de escena
    void Start()
    {
        if (instance == null)
        {
            gameObject.SetActive(true);
            instance = this;
            DontDestroyOnLoad(gameObject);
            musicaMenu = GetComponent<AudioSource>();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    //Al activarse el objeto llama a onsceneloaded
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Al desactivarse el objeto llama a onsceneloaded
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //Si la nueva escena que se accedio no es main (juego), sigue la musica, sino se detiene
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Detiene la música si se carga la escena específica
        if (scene.name == escenaJuego && musicaMenu.isPlaying)
        {
            musicaMenu.Stop();
        }
        else
        {
            if (!musicaMenu.isPlaying)
            {
                musicaMenu.Play();
            }
        }
    }
}
