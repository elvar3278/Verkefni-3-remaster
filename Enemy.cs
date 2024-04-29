using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    public float speed = 3.0f;
    private Transform target; // Reference to the player's transform

    void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
    }

    void Update()
    {
        if (target != null)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // You can add death animation or particle effects here
        Destroy(gameObject);
    }
}
