using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class VidaEnemigo : MonoBehaviour
{
    public GameObject vidamarmota;
    int vidaactual;
    public int vidamax = 10;
    int valorMonedas;
    public int valorMinMonedas;
    public int valorMaxMonedas;
    public GameObject player;
    public Slider barraDeVida;
    public Slider barraDeVidaAmarilla;
    private float velBarraAmarilla = 0.05f;
    public float tiempovida = 0.0f;


    public UnityEvent OnDeath;

    void Start()
    {
        vidamarmota.SetActive(false);
        vidaactual = vidamax;
        barraDeVida.maxValue = vidamax;
        barraDeVida.value = vidaactual;
        barraDeVidaAmarilla.value = vidaactual;
        barraDeVidaAmarilla.maxValue = vidamax;
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        ReducirVida(damage);
        if (vidaactual <= 0)
        {
            Die();
        }
    }

    public void ReducirVida(int cantidad)
    {
        vidamarmota.SetActive(true);
        vidaactual -= cantidad;
        vidaactual = Mathf.Clamp(vidaactual, 0, vidamax);
        barraDeVida.value = vidaactual;
        tiempovida = 0f;
        


    }

    // Method to check if enemy is dead
    public bool IsDead()
    {

        return vidaactual <= 0;
    }

    void Update()
    {
        tiempovida += Time.deltaTime;
        if (barraDeVida.value != barraDeVidaAmarilla.value)
        {
            barraDeVidaAmarilla.value = Mathf.Lerp(barraDeVidaAmarilla.value, vidaactual, velBarraAmarilla);
            if (tiempovida >= 2f)
            {
                vidamarmota.SetActive(false);
                tiempovida = 0f;
            }
            
        }
      
    }

    // Method to handle enemy death
   
    private void Die()
    {
        valorMonedas = UnityEngine.Random.Range(valorMinMonedas, valorMaxMonedas + 1);
        player.GetComponent<economiaJugador>().RecibirMonedas(valorMonedas);
        OnDeath.Invoke();
        gameObject.SetActive(false);
    }
}