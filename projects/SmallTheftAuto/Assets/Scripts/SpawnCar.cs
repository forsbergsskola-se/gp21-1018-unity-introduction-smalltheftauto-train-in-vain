using System;
using Unity.Mathematics;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject carPrefab;

    private PlayerDrive playerDrive;

    void Start()
    {
        playerDrive = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDrive>();

        Spawn(new Vector3(0, 1.8f, 0));
        Spawn(new Vector3(-10, 1.8f, 0));
        Spawn(new Vector3(10, 1.8f, 0));
    }

    public void Spawn(Vector3 spawnPosition, Quaternion rotation = new Quaternion())
    {
        var car = Instantiate(carPrefab);
        car.transform.position = spawnPosition;
        car.transform.rotation = rotation;
        playerDrive.carsInScene.Add(car);
    }
    
    public GameObject SpawnAndReturn(Vector3 spawnPosition, Quaternion rotation = new Quaternion())
    {
        var car = Instantiate(carPrefab);
        car.transform.position = spawnPosition;
        car.transform.rotation = rotation;
        playerDrive.carsInScene.Add(car);
        return car;
    }
}
