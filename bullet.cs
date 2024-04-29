using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Destroy the enemy object
            Destroy(other.gameObject);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
