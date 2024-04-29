using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Public variables
    public int maxHealth = 50; // Maximum health of the enemy
    public float speed = 3.0f; // Movement speed of the enemy

    // Private variables
    private int currentHealth; // Current health of the enemy
    private Transform target; // Reference to the player's transform

    void Start()
    {
        // Initialize current health to max health
        currentHealth = maxHealth;
        
        // Find the player's transform using the tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if the target (player) exists
        if (target != null)
        {
            // Move towards the player using MoveTowards function
            // Move the enemy's position towards the player's position with a speed determined by 'speed' and Time.deltaTime
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    // Method to decrease enemy's health when taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce current health by the damage amount
        
        // Check if current health is less than or equal to 0
        if (currentHealth <= 0)
        {
            Die(); // Call Die method if health is 0 or below
        }
    }

    // Method to handle enemy death
    void Die()
    {
        // You can add death animation or particle effects here
        
        // Destroy the enemy gameObject
        Destroy(gameObject);
    }
}

