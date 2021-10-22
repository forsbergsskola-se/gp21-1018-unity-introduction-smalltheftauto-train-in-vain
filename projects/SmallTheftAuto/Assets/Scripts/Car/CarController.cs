using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Field for the CarMovement script
    public CarMovement carMovement;
    
    // // Field for the CarExitChecker script
    public CarExitChecker CarExitChecker;

    // Variables to hold if the car is on fire or running.
    private bool isRunning;
    private bool isBurning;
    
    // The max health of the car.
    public int MaxHealth;
    
    
    private int health;
    public int Health
    {
        get { return Health; }
        set
        {
            health -= value;
            // If the car is below 25% health start burning.
            if (health < MaxHealth / 4 && !isBurning)
            {
                CarIsBurning();
            }
            if (health <= 0)
            {
                CarExplode();
            }
        }
    }
    
    
    
    /// <summary>
    /// True/false will turn on and turn of the car.
    /// </summary>
    public bool IsRunning
    {
        set
        {
            isRunning = value;
            carMovement.enabled = isRunning;
            CarExitChecker.enabled = isRunning;
        }
    }



    void CarIsBurning()
    {
        //TODO Change the sprite of the car to be on fire.
        
        isBurning = true;
    }

    
    
    void CarExplode()
    {
        // TODO: Kill the player.
        // TODO: Destroy the car.
        // TODO: Possibly leave a car wreck behind where it died?
        
        IsRunning = false;
    }
    
    
    
    void Start()
    {
        Health = MaxHealth;
    }
}
