using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public int healthUp;
    private int currentHealth;
    

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        currentHealth = playerHealth.currentHealth;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        
        if (other.CompareTag("Player") && (currentHealth != 100))
        {
            playerHealth.TakeDamage(- healthUp);
            Destroy(gameObject);
        }

        else
        {
             Debug.Log("Player has full health");
        }
    }
}
