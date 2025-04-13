using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int startingHealth = 3;

    [SerializeField]
    int currentHealth;

    [SerializeField]
    GameObject deathVFX;

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
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
