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

    // Field for the CarSpriteChanger script to change the texture of the car.
    public CarSpriteChanger CarSpriteChanger;


    // Todo: Don't use GetComponent multiple times, instead use a field that gets it once from the start. 

    
    
    void Start()
    {
        // Get the player object.
        Player = GameObject.FindGameObjectWithTag("Player");
        
        // Get the camera component.
        FollowCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>();
    }
    
    
    
    public void Enter()
    {
        // If for some reason the player is null, search and find it again.
        if (Player == null) Player = GameObject.FindGameObjectWithTag("Player");

        // Disable the player.
        Player.SetActive(false);

        // Make the camera target the car.
        FollowCamera.target = gameObject;

        // Start the car.
        gameObject.GetComponent<CarController>().IsRunning = true;

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
        
        // Stop the car.
        gameObject.GetComponent<CarController>().IsRunning = false;
        
        // Make the player the target of the camera.
        FollowCamera.target = Player;
    }
}
