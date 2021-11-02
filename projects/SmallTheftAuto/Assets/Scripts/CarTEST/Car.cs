using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Entity, IDriveable, IEnterable
{
    // Constructor
    public Car() : base()
    {
    }


    public override void TakeDamage(int value)
    {
        base.TakeDamage(value);
        if (Health < MaxHealth / 4)
        {
            IsBurning = true;
            UpdateSprite();
        }
    }


    private bool CarRunning;
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
    // IEnterable
    
    private FollowCamera followCamera;
    private Transform ExitPosition;
    private GameObject currentUser;
    
    

    public void Enter(GameObject User)
    {
        currentUser = User;
        currentUser.SetActive(false);
        followCamera.target = gameObject;
        CarRunning = true;
        
        // Allow the car to be exited after half a second.
        Invoke("ExitCooldown", 0.5f);
        
        // TODO: ADD CAR SPRITE CHANGE HERE.----------------------------------------------------------------------------
        UpdateSprite();
    }

    
    
    void ExitCooldown()
    {
        ExitAllowed = true;
    }

    
    
    public void Exit()
    {
        currentUser.transform.position = ExitPosition.position;
        currentUser.transform.rotation = ExitPosition.rotation;

        currentUser.SetActive(true);
        followCamera.target = currentUser;
        currentUser = null;
        
        
        CarRunning = false;

        // TODO: ADD CAR SPRITE CHANGE HERE.----------------------------------------------------------------------------
        UpdateSprite();
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
}
