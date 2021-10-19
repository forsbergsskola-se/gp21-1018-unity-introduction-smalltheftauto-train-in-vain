using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private bool isBurning;
    
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
    
    public int MaxHealth;



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
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
