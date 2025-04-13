using System;
using Cinemachine;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    int startingHealth = 5;

    [SerializeField]
    int currentHealth;

    [SerializeField]
    CinemachineVirtualCamera deathVirtualCamera;
    
    [SerializeField]
    Transform weaponCamera;

    int gameOverVirtualCameraPriority = 20;

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
        weaponCamera.parent = null;
        deathVirtualCamera.Priority = gameOverVirtualCameraPriority;
        Destroy(gameObject);
    }
}
