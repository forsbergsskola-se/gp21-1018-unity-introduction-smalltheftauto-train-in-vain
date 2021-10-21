using System;
using UnityEngine;


/// <summary>
/// Handles the driver of the car. Will enable car features when entered.
/// </summary>
public class HandlePassenger : MonoBehaviour
{
    // Prepare a private field for the player.
    private GameObject Player;
    
    // Prepare a private field for the camera.
    private FollowCamera FollowCamera;
    
    // Field for the child ExitPosition of Car.
    public GameObject ExitPosition;
    
    // Field for the CarMovement script
    public CarMovement CarMovement;
    
    // Field for the CarController.
    public CarController CarController;

    // Field for the CarSpriteChanger script to change the texture of the car.
    public CarSpriteChanger CarSpriteChanger;


    private bool CanExit = false;
    
    

    // Constant variable which holds what key is pressed to exit the vehicle.
    private const KeyCode VehicleInteract = KeyCode.F;
    
    void Start()
    {
        // Get the player object.
        Player = GameObject.FindGameObjectWithTag("Player");
        
        // Get the camera component.
        FollowCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>();
    }

    private void Update()
    {
        if (!Player.activeInHierarchy && Input.GetKeyDown(VehicleInteract) && GetComponent<CarController>().IsRunning)
        {
            Exit();
            // CanExit = false;
        }
    }

    public void Enter()
    {
        // If for some reason the player is null, search and find it again.
        if (Player == null) Player = GameObject.FindGameObjectWithTag("Player");
        
        // CanExit = true;
        
        // Disable the player.
        Player.SetActive(false);

        // Make the camera target the car.
        FollowCamera.target = gameObject;

        // Enable the car movement.
        CarMovement.enabled = true;

        GetComponent<CarController>().IsRunning = true;

        // Make the car sprite show a player in the car.
        CarSpriteChanger.PlayerInCar = true;
    }

    public void Exit()
    {
        // Make the car sprite show a empty window again and no player.
        CarSpriteChanger.PlayerInCar = false;
        
        // Set the player position to next to the car like if they exited the left door.
        Player.transform.position = ExitPosition.transform.position;
        
        // Enable the player again.
        Player.SetActive(true);
        
        GetComponent<CarController>().IsRunning = false;
        
        // Make the player the target of the camera.
        FollowCamera.target = Player;
        
        // Disable the driving script.
        CarMovement.enabled = false;
    }
}
