using System;
using UnityEngine;
using UnityEngine.Events;
public class VidaEnemigo : MonoBehaviour
{
    int vidaactual;
    public int vidamax = 10;
    int valorMonedas;
    public int valorMinMonedas;
    public int valorMaxMonedas;
    public GameObject player;


    public UnityEvent OnDeath;

    void Start()
    {
        vidaactual = vidamax;
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        vidaactual -= damage;
        if (vidaactual <= 0)
        {
            Die();
        }
    }

    // Method to check if enemy is dead
    public bool IsDead()
    {

        return vidaactual <= 0;
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