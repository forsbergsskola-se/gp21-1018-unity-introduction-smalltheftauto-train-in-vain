using UnityEngine;

public class CarController : MonoBehaviour
{
    // Field for the CarMovement script
    public CarMovement carMovement;
    
    // // Field for the CarExitChecker script
    public CarExitChecker CarExitChecker;

    private CarTakeDamage carTakeDamage;
    private CarSpriteChanger carSpriteChanger;

    // Variables to hold if the car is on fire or running.
    private bool isRunning;
    private bool isBurning;
    private const int MaxHealth = 300; // NOTE: Completely arbitrary, can be adjusted
    
    // The max health of the car.
    private int maxHealth = MaxHealth;
    private GameObject Player;
    
    
    private int health;
    public int Health
    {
        get => health;
        set
        {
            health = value;
            // If the car is below 25% health start burning.
            if (health < maxHealth / 4 && !isBurning) CarIsBurning(); // NOTE: Add animation here
            if (health <= 0) CarExplode();
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

    private void Awake()
    {
        carTakeDamage = GetComponent<CarTakeDamage>();
        carSpriteChanger = GetComponent<CarSpriteChanger>();
        Player = GameObject.FindGameObjectWithTag ("Player");
    }

    void Start()
    {
        Health = maxHealth;
        Debug.Log("Current health: " + Health);
    }


    void CarIsBurning() 
    {
        //TODO Change the sprite of the car to be on fire.
        
        isBurning = true;
        carSpriteChanger.PlayerInCarBurning();
    }

    
    
    void CarExplode()
    {
        // TODO: Kill the player.
        // TODO: Destroy the car.
        // TODO: Possibly leave a car wreck behind where it died?
        
        
        Player.GetComponent<PlayerHealth>().TakeDamage(999);
        IsRunning = false;
    }

    public void OnCarCollideAgainstCar()
    {
        carTakeDamage.TakeDamage(this);
        Debug.Log("Current health: " + Health);
    }
}
