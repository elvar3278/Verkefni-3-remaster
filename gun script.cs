using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform bulletSpawnPoint; // Point where the bullet will spawn
    public float bulletSpeed = 20f;

    void Start()
    {
        // Set the player GameObject as the parent of the gun GameObject
        transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate a new bullet GameObject at the bullet spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Get the rigidbody component of the bullet
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Apply forward force to the bullet
        bulletRb.velocity = bulletSpawnPoint.forward * bulletSpeed;
    }
}
