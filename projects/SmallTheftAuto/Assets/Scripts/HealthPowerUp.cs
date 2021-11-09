using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public int healthUp;
    private PlayerController playerController;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        playerController = FindObjectOfType<PlayerController>();

        if (other.CompareTag("Player") && (playerController.Health != playerController.MaxHealth))
        {
            playerController.TakeDamage(-healthUp);
            Destroy(this.gameObject);
        }
    }
}
