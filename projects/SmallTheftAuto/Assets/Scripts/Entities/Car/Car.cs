using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Entity, IDriveable, IEnterable, IDamageable, IInteractable
{
    // Constructor
    public Car() : base()
    {
    }


    public bool CarRunning;
    private bool ExitAllowed;
    private const KeyCode VehicleInteractKey = KeyCode.F;
    
    
    private void Start()
    {
        // IEnterable
        followCamera = FindObjectOfType<FollowCamera>();
        ExitPosition = transform.Find("CarExitPosition");
        
        // CarSpriteChanger
        onFireAnimation = GetComponentInChildren<Animator>();
        onFireAnimation.enabled = false;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    
    
    
    // Main loop
    private void Update()
    {
        if (currentUser != null && Input.GetKeyDown(VehicleInteractKey) && ExitAllowed)
            Exit();
        if (CarRunning)
        {
            Drive();
        }
    }

    
    
    
    
    // #################################################################################################################
    // IDriveable

    public float MaxSpeed = 30f;
    public float MaxTurnSpeed = 150f;
    private float verticalSpeed;
    public void Drive()
    {
        verticalSpeed = Input.GetAxis("Vertical") * MaxSpeed * Time.deltaTime;
        var turnSpeed = Input.GetAxis("Horizontal") * (MaxTurnSpeed + verticalSpeed) * Time.deltaTime;

        if (verticalSpeed != 0) 
            transform.Rotate(0, 0, -turnSpeed);
        if (verticalSpeed < 0)
            transform.Translate(0, verticalSpeed / 2, 0);
        else
            transform.Translate(0, verticalSpeed, 0);
    }


    
    
    
    // #################################################################################################################
    // IEnterable && IInteractable
    
    private FollowCamera followCamera;
    private Transform ExitPosition;
    private GameObject currentUser;



    public void Interact(GameObject User)
    {
        Enter(User);
    }
    
    

    public void Enter(GameObject User)
    {
        currentUser = User;
        currentUser.SetActive(false);
        followCamera.target = gameObject;
        followCamera.CameraHeightOffset = -40;
        CarRunning = true;
        CollisionCheckActive = true;
        
        // Allow the car to be exited after half a second.
        Invoke("ExitCooldown", 0.5f);
        
        UpdateSprite();
    }

    
    
    void ExitCooldown()
    {
        ExitAllowed = true;
    }

    
    
    public void Exit()
    {
        if (currentUser != null)
        {
            currentUser.transform.position = ExitPosition.position;
            currentUser.transform.rotation = ExitPosition.rotation;

            currentUser.SetActive(true);
            followCamera.target = currentUser;
            followCamera.CameraHeightOffset = -20;
            currentUser = null;
        
        
            CarRunning = false;
            CollisionCheckActive = false;

            UpdateSprite();
        }
    }
    
    
    
    
    
    // #################################################################################################################
    // CarSpriteChanger

    private Animator onFireAnimation;
    private SpriteRenderer spriteRenderer;

    public Sprite drivingSkin;
    public Sprite defaultSkin;

    private bool IsBurning;

    void UpdateSprite()
    {
        if (IsBurning)
        {
            Debug.Log("Car is burning! " + IsBurning);
            Debug.Log("Car health: " + Health);
            Debug.Log($"Maxhealth = {MaxHealth}");
            if (currentUser != null)
            {
                onFireAnimation.enabled = true;
                onFireAnimation.runtimeAnimatorController = Resources.Load("Animations/Car On FireDriving") as RuntimeAnimatorController;
            }
            else
            {
                onFireAnimation.enabled = true;
                onFireAnimation.runtimeAnimatorController = Resources.Load("Animations/Car On Fire") as RuntimeAnimatorController;
            }
        }
        spriteRenderer.sprite = currentUser != null ? drivingSkin : defaultSkin;
    }
    
    
    
    
    
    // #################################################################################################################
    // CarCollisions
    
    private const int MaxDamage = 500;
    private bool CollisionCheckActive;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (CollisionCheckActive)
        {
            if (other.gameObject.TryGetComponent(out IDamageable iDamageable))
            {
                iDamageable.TakeDamage(CalculateCrashDamage(), gameObject);
            }
            TakeDamage(CalculateCrashDamage(), gameObject);
        }
    }

    int CalculateCrashDamage()
    {
        return Math.Abs((int) Math.Round(MaxDamage * verticalSpeed));
    }
    
    
    
    
    
    // #################################################################################################################
    // CarDeath

    public override void OnDeath()
    {
        FindObjectOfType<FireSpawner>().SpawnFire(transform.position);
        if (currentUser != null)
        {
            Exit();
            // currentUser.GetComponent<PlayerController>().TakeDamage(9999);
            FindObjectOfType<PlayerController>().TakeDamage(9999);
        }
        base.OnDeath();
    }





    // #################################################################################################################
    // TakeDamage
    
    
    public override void TakeDamage(int value, GameObject attacker)
    {
        if (attacker.TryGetComponent(out TAG_WaterDamage noUseCase))
        {
            Debug.Log("Car takes a swim but sinks instantly!");
            value *= 1000;
        }
        base.TakeDamage(value, attacker);
        Debug.Log($"Car takes {value} damage!");
        if (Health < MaxHealth / 4)
        {
            IsBurning = true;
            UpdateSprite();
        }
        // if (Health <= 0)
        //     CarExplode();
    }
}