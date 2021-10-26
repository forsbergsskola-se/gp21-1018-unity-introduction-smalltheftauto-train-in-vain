using System;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject carPrefab;

    private PlayerDrive playerDrive;

    void Start()
    {
        playerDrive = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDrive>();

        Spawn(new Vector3(0, 1.8f, 0), new Vector3(0, 0, 0));
        Spawn(new Vector3(-10, 1.8f, 0), new Vector3(0, 0, 0));
        Spawn(new Vector3(10, 1.8f, 0), new Vector3(0, 0, 0));

        // var car = Instantiate(carPrefab);
        // car.transform.position = new Vector3(0, 1.8f, 0);
        // car.GetComponent<CarMovement>().enabled = false;
        //
        // var car2 = Instantiate(carPrefab);
        // car2.transform.position = new Vector3(-10, 1.8f, 0);
        // car2.GetComponent<CarMovement>().enabled = false;
        //
        // var car3 = Instantiate(carPrefab);
        // car3.transform.position = new Vector3(10, 1.8f, 0);
        // car3.GetComponent<CarMovement>().enabled = false;
    }

    public void Spawn(Vector3 spawnPosition, Vector3 rotation)
    {
        var car = Instantiate(carPrefab);
        car.transform.position = spawnPosition;
        // Todo: Add rotation support.----------------------------------------------------------------------------------
        playerDrive.carsInScene.Add(car);
    }
    
    public GameObject SpawnAndReturn(Vector3 spawnPosition, Vector3 rotation)
    {
        var car = Instantiate(carPrefab);
        car.transform.position = spawnPosition;
        // Todo: Add rotation support.----------------------------------------------------------------------------------
        playerDrive.carsInScene.Add(car);
        return car;
    }
}
