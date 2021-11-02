using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private int healthUp;
    

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        
        if (other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(50);
            Destroy(gameObject);
        }
    }

    public void HealthIncrease(int healthToAdd)
    {
        healthUp += healthToAdd;
    }

}
