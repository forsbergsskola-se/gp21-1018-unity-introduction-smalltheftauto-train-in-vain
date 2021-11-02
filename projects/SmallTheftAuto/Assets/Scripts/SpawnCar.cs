using System;
using Unity.Mathematics;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    // public GameObject carPrefab;
    public GameObject NewCarPrefab;

    private PlayerDrive playerDrive;

    void Start()
    {
        playerDrive = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDrive>();

        SpawnUpgraded(new Vector3(0, 1.8f, 0));
        SpawnUpgraded(new Vector3(-10, 1.8f, 0));
        SpawnUpgraded(new Vector3(10, 1.8f, 0));
        // SpawnUpgraded(new Vector3(0, 10, 0));
        // SpawnUpgraded(new Vector3(-10, 10, 0));
    }

    // public void Spawn(Vector3 spawnPosition, Quaternion rotation = new Quaternion())
    // {
    //     var car = Instantiate(carPrefab);
    //     car.transform.position = spawnPosition;
    //     car.transform.rotation = rotation;
    //     playerDrive.carsInScene.Add(car);
    // }
    //
    // public GameObject SpawnAndReturn(Vector3 spawnPosition, Quaternion rotation = new Quaternion())
    // {
    //     var car = Instantiate(carPrefab);
    //     car.transform.position = spawnPosition;
    //     car.transform.rotation = rotation;
    //     playerDrive.carsInScene.Add(car);
    //     return car;
    // }

    public void SpawnUpgraded(Vector3 spawnPosition, Quaternion rotation = new Quaternion())
    {
        var car = Instantiate(NewCarPrefab);
        car.transform.position = spawnPosition;
        car.transform.rotation = rotation;
        playerDrive.Enterables.Add(car);
    }
    
    public GameObject SpawnUpgradedAndReturn(Vector3 spawnPosition, Quaternion rotation = new Quaternion())
    {
        var car = Instantiate(NewCarPrefab);
        car.transform.position = spawnPosition;
        car.transform.rotation = rotation;
        playerDrive.Enterables.Add(car);
        return car;
    }
}
