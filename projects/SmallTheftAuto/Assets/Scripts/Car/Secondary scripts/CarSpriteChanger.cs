using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpriteChanger : MonoBehaviour
{
    // Gets the Spriterenderer for changing car sprites.
    private SpriteRenderer spriteRenderer;
    private Animator onFireAnimation;

    // Gets the sprites to change between.
    public Sprite drivingSkin;
    public Sprite defaultSkin;

    private bool playerInCar;

    /// <summary>
    /// Sets the sprite to represent a player sitting in the car if passed true, and a empty car if passed a false.
    /// </summary>
    private void Awake()
    {
        onFireAnimation = GetComponentInChildren<Animator>();
        onFireAnimation.enabled = false;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public bool PlayerInCar
    {
        set
        {
            // Set playerInCar to input value.
            playerInCar = value;

            // Set the skin depending on if the player is in the car or not.
            spriteRenderer.sprite = playerInCar ? drivingSkin : defaultSkin;
        }
    }

    public void PlayerInCarBurning()
    {
        onFireAnimation.enabled = true;
        onFireAnimation.runtimeAnimatorController = Resources.Load("Animations/Car On FireDriving") as RuntimeAnimatorController;

    }

    public void CarBurning()
    {
        onFireAnimation.enabled = true;
        onFireAnimation.runtimeAnimatorController = Resources.Load("Animations/Car On Fire") as RuntimeAnimatorController;
    }
}
