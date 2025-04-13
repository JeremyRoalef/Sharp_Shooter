using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    int startingHealth = 5;

    [SerializeField]
    int currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
