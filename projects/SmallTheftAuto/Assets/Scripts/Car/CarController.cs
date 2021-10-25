using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    // Field for the CarMovement script
    public CarMovement carMovement;
    
    // // Field for the CarExitChecker script
    public CarExitChecker CarExitChecker;

    private CarTakeDamage carTakeDamage;
    private CarSpriteChanger carSpriteChanger;
    public SpawnCar SpawnCar;
    public GameObject firePrefab;

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
        
        // This will get the player object directly from the stashed player in GameController since the
        // player might be inactive, and there for impossible to find.
        Player = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().Player;
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

    private void Update()
    {
        
        // loads fire driving animation when car reaches high damage
        if (isRunning && isBurning)
        {
            carSpriteChanger.PlayerInCarBurning();
        }
        
        // keeps default car fire animation when leaving car
        else if (!isRunning && isBurning)
        {
            carSpriteChanger.CarBurning();
        }
    }


    public void CarExplode()
    {
        if (isRunning == true)
        {
            IsRunning = false;
            CarExitChecker.HandlePassenger.ExitCar();
            Player.transform.position = this.gameObject.transform.position;
            var fire = Instantiate(firePrefab);
            fire.transform.position = this.transform.position;    
            Destroy(this.gameObject); 
            Player.GetComponent<PlayerHealth>().TakeDamage(999);
        }

        else
        {
            var fire = Instantiate(firePrefab);
            fire.transform.position = this.transform.position;    
            Destroy(this.gameObject); 
        }
    }

    public void OnCarCollideAgainstCar()
    {
        carTakeDamage.TakeDamage();
        Debug.Log("Current health: " + Health);
    }
}
