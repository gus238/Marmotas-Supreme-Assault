using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicaEntreEscenas : MonoBehaviour
{
    private static musicaEntreEscenas instance;
    public AudioSource musicaMenu;
    public string escenaJuego;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            musicaMenu = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnEnable()
    {
        // Suscribe el método para detectar cambios de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        // Anula la suscripción para evitar errores
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Detiene la música si se carga la escena específica
        if (scene.name == escenaJuego && musicaMenu.isPlaying)
        {
            musicaMenu.Stop();
        }
    }
}
