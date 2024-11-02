using System;
using UnityEngine;
using UnityEngine.Events;

public class VidaEnemigo : MonoBehaviour
{
    public int vidamax = 10;
    int vidaactual;

    // Event to handle enemy death
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
        gameObject.SetActive(false);
        OnDeath.Invoke();
    }
}
