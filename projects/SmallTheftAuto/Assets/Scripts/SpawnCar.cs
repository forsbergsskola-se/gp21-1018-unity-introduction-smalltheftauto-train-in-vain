using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCar : MonoBehaviour
{
    // public GameObject carPrefab;
    public GameObject NewCarPrefab;

    // private PlayerDrive playerDrive;
    private PlayerInteract playerInteract;
    
    List<Vector3> spawnPositions = new List<Vector3>();
    
    void Start()
    {
        // playerDrive = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDrive>();
        playerInteract = FindObjectOfType<PlayerInteract>();
        // playerInteract = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>();
        
        SpawnUpgraded(new Vector3(-10, 1.8f, 0));
        SpawnUpgraded(new Vector3(-30, 1.8f, 0));
        SpawnUpgraded(new Vector3(-20, 1.8f, 0));
        // SpawnUpgraded(new Vector3(0, 10, 0));
        // SpawnUpgraded(new Vector3(-10, 10, 0));
        
        var spawnObjects = FindObjectsOfType<TAG_TrafficPoint>().ToList();
        foreach (TAG_TrafficPoint t in spawnObjects)
        {
            spawnPositions.Add(t.gameObject.transform.position);
        }
    }
    

    public void SpawnUpgraded(Vector3 spawnPosition, Quaternion rotation = new Quaternion(), bool NPCDriver = false)
    {
        var car = Instantiate(NewCarPrefab);
        car.transform.position = spawnPosition;
        car.transform.rotation = rotation;
        car.GetComponent<AiDriving>().NPCInCar = NPCDriver;
        playerInteract.Interactables.Add(car);
    }
    
    public GameObject SpawnUpgradedAndReturn(Vector3 spawnPosition, Quaternion rotation = new Quaternion(), bool NPCDriver = false)
    {
        var car = Instantiate(NewCarPrefab);
        car.transform.position = spawnPosition;
        car.transform.rotation = rotation;
        car.GetComponent<AiDriving>().NPCInCar = NPCDriver;
        playerInteract.Interactables.Add(car);
        return car;
    }

    public int MaxCars;
    private bool spawnOnCoolDown;
    private List<GameObject> npcCars = new List<GameObject>();
    void Update()
    {
        npcCars.RemoveAll(x => x == null);
        if (npcCars.Count < MaxCars && !spawnOnCoolDown)
        {
            Invoke("SpawnCoolDown", 0.2f);
            var car = SpawnUpgradedAndReturn(spawnPositions[Random.Range(0, spawnPositions.Count)], new Quaternion(), true);
            npcCars.Add(car);
        }
    }

    void SpawnCoolDown()
    {
        spawnOnCoolDown = false;
    }
    
    // public void SpawnNPCCars(int amount)
    // {
    //     var spawnObjects = FindObjectsOfType<TAG_TrafficPoint>().ToList();
    //     var spawnPositions = new List<Vector3>();
    //     foreach (TAG_TrafficPoint t in spawnObjects)
    //     {
    //         spawnPositions.Add(t.gameObject.transform.position);
    //     }
    //     
    //     
    // }
}
