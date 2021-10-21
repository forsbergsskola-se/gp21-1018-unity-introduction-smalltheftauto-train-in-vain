using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpriteChanger : MonoBehaviour
{
    // Gets the Spriterenderer for changing car sprites.
    private SpriteRenderer spriteRenderer;
    
    // Gets the sprites to change between.
    public Sprite drivingSkin;
    public Sprite defaultSkin;

    private bool playerInCar;
    
    /// <summary>
    /// Sets the sprite to represent a player sitting in the car if passed true, and a empty car if passed a false.
    /// </summary>
    public bool PlayerInCar
    {
        set
        {
            // Set playerInCar to input value.
            playerInCar = value;
            
            if (playerInCar)
            {
                // Change the sprite to show the player driving it.
                spriteRenderer.sprite = drivingSkin;
            }
            // If the player is not in the car.
            else
            {
                // Change the sprite back to be an empty car.
                spriteRenderer.sprite = defaultSkin;
            }
        }
    }

    private void Start()
    {
        // Get the SpriteRenderer object to allow for texture changes.
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }
}