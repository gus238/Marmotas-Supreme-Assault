using System;
using UnityEngine;
using UnityEngine.Events;

public class VidaEnemigo : MonoBehaviour
{
    public int MaxHealth { get; private set; } = 100;
    int currentHealth;

    // Event to handle enemy death
    public UnityEvent OnDeath;

    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, MaxHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method to check if enemy is dead
    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    // Method to handle enemy death
    private void Die()
    {
        // Invoke the death event to allow flexible handling of enemy death
        OnDeath?.Invoke();
    }
}
