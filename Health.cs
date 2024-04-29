using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Public variables
    public int maxHealth = 100; // Maximum health of the player

    // Public variables
    public Text healthText; // Reference to the UI text element to display health

    void Start()
    {
        // Initialize current health to max health
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // Triggered when the player collides with another Collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the Collider belongs to an enemy
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(100); // Instant death if touched by an enemy
        }
    }

    // Method to decrease player's health when taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce current health by the damage amount
        UpdateHealthUI(); // Update UI to reflect the change in health

        // Check if current health is less than or equal to 0
        if (currentHealth <= 0)
        {
            Die(); // Call Die method if health is 0 or below
        }
    }

    // Method to handle player death
    void Die()
    {
        // You can add game over logic here
        Debug.Log("Player has died.");
    }

    // Method to update UI with current health
    void UpdateHealthUI()
    {
        // Check if the healthText reference is not null
        if (healthText != null)
        {
            // Update the UI text with current health
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }
}

