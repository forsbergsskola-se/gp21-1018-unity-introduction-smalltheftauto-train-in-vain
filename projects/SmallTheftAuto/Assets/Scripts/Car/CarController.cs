using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Prepare a private field for the player.
    private GameObject Player;
    
    // Field for the CarMovement script
    private CarMovement carMovement;

    // Constant variable which holds what key is pressed to exit the vehicle.
    private const KeyCode VehicleInteract = KeyCode.F;
    
    // Variables to hold if the car is on fire or running.
    private bool isRunning = false;
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
    
    

    public bool IsRunning
    {
        set
        {
            isRunning = value;
            carMovement.enabled = isRunning;
        }
    }



    // private void Update()
    // {
    //     //Check if the player wants to leave the car.
    //     if (isRunning && !Player.activeInHierarchy && Input.GetKeyDown(VehicleInteract))
    //     {
    //         // Exit the car.
    //         gameObject.GetComponent<HandlePassenger>().Exit();
    //     }
    // }

    public void HandlePlayerExitCar()
    {
        gameObject.GetComponent<HandlePassenger>().Exit();
    }


    void CarIsBurning()
    {
        // AJAJAJAJ DET BRINNER FAN RING AMBUL-NEJ-BRANDKÅREN FORT FAN FAN FAN. 
     
        // Change the sprite of the car to be on fire.
        isBurning = true;
    }

    
    
    void CarExplode()
    {
        // Kill the player.
        // Destroy the car.
        // Possibly leave a car wreck behind where it died?
        IsRunning = false;
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        // Set health to maxHealth on spawn.
        Health = MaxHealth;
        
        // Get the player object.
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Awake()
    {
        carMovement = gameObject.GetComponent<CarMovement>();
    }
}
