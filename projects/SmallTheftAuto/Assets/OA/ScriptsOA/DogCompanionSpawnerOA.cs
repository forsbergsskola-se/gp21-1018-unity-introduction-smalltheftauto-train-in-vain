using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCompanionSpawnerOA : MonoBehaviour
{
    public GameObject dogPrefab;

    void OnEnable()
    {
        Instantiate(dogPrefab);
    }

    void OnDisable()
    {
        Destroy(dogPrefab);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
