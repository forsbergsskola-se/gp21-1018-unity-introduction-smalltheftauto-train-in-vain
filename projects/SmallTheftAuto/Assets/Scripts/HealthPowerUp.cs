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
        // TODO: not a huge fan of this caching here. I don't think that you need this "performance boost" and it makes your game
        // less flexible as it cannot react to multiple players or player respawns
        playerController = FindObjectOfType<PlayerController>();
    }

    // TODO: Well done!
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && (playerController.Health != playerController.MaxHealth))
        {
            playerController.TakeDamage(-healthUp);
            Destroy(gameObject);
        }
    }
}
