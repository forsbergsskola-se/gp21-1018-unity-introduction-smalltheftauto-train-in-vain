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


    private bool CarRunning;
    private const KeyCode VehicleInteractKey = KeyCode.F;
    // Main loop
    private void Update()
    {
        if (currentUser != null && Input.GetKeyDown(VehicleInteractKey))
            Exit();
        if (CarRunning)
        {
            Drive();
        }
    }


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


    private FollowCamera followCamera;
    private Transform ExitPosition;
    private void Start()
    {
        followCamera = FindObjectOfType<FollowCamera>();
        ExitPosition = transform.Find("CarExitPosition");
    }
    
    private GameObject currentUser;
    public void Enter(GameObject User)
    {
        currentUser = User;
        currentUser.SetActive(false);
        followCamera.target = gameObject;
        CarRunning = true;
        
        // TODO: ADD CAR SPRITE CHANGE HERE.---------------------------------------------------------------------------_
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
    }
}
