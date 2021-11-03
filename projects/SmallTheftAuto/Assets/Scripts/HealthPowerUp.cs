using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public int healthUp;
    private PlayerController playerController;
    

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        
        if (other.CompareTag("Player") && (playerController.Health != playerController.MaxHealth))
        {
            playerController.TakeDamage(-healthUp);
            Destroy(gameObject);
        }
        else
        {
             Debug.Log("Player has full health");
        }
    }
}
