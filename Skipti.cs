using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipti : MonoBehaviour
{
    void Start()
    {
        Debug.Log("byrja"); // Output "byrja" to the console when the script starts
    }

    // Triggered when another Collider enters the trigger zone of this GameObject
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false); // Deactivate the GameObject that entered the trigger zone
        StartCoroutine(Bida()); // Start a coroutine named Bida
    }

    // Coroutine function to wait for a specified duration before proceeding
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        Endurræsa(); // Call the Endurræsa method after waiting
    }

    // Method to load the next scene in the build index
    public void Endurræsa()
    {
        // Load the next scene in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

