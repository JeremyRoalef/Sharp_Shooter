using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int startingHealth = 3;

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

    void Die()
    {
        //Temporary
        Destroy(gameObject);
    }
}
