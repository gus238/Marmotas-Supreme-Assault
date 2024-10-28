using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar el nivel o cargar escenas

public class GameManager : MonoBehaviour
{
    public int oleadasParaGanar = 2; // N�mero de oleadas necesarias para ganar
    public PasarOleada pasarOleada;  // Referencia al script de oleadas
    public BarraDeVida barraDeVida;  // Referencia al script de la barra de vida

    private bool juegoTerminado = false; // Indica si el juego ha terminado

    void Update()
    {
        if (juegoTerminado) return;

        // Verificar si el jugador ha ganado
        if (pasarOleada.NumDeOleada > oleadasParaGanar)
        {
            GanarJuego();
        }

        // Verificar si el jugador ha perdido
        if (barraDeVida.vidaActual <= 0) 
        {
            PerderJuego();
        }
    }

    // M�todo para manejar la victoria
    void GanarJuego()
    {
        juegoTerminado = true;
        Debug.Log("�Has ganado el juego!");

    }

    // M�todo para manejar la derrota
    void PerderJuego()
    {
        juegoTerminado = true;
        Debug.Log("Has perdido el juego.");
        
    }

    // M�todo para reducir la vida del jugador
    public void ReducirVida(float cantidad)
    {
        barraDeVida.ReducirVida(cantidad); 
        if (barraDeVida.vidaActual <= 0 && !juegoTerminado)
        {
            PerderJuego();
        }
    }
}
