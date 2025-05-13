using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    // Reference to the GameManager for pausing and message display
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();  // Find the GameManager in the scene
    }

    // Detect when the player collides with the sign
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Ensure it's the player that collides
        {
            gameManager.PauseGame("Tutorial!   Destroy all Targets to move on ");  // Call the PauseGame method in the GameManager
        }
    }
}
