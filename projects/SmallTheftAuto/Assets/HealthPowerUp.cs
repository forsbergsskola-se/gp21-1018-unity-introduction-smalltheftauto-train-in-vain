using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public int healthUp;
    

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        
        if (other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(- healthUp);
            Destroy(gameObject);
        }
    }
}
