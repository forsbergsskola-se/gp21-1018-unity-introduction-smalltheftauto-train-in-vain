using System;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject carPrefab;

    void Start()
    {
        var car = Instantiate(carPrefab);
        car.transform.position = new Vector3(0, 1.8f, 0);
        car.GetComponent<CarMovement>().enabled = false;
        
        var car2 = Instantiate(carPrefab);
        Debug.Log("CAR2: " + car2);
        car2.transform.position = new Vector3(-10, 1.8f, 0);
        car2.GetComponent<CarMovement>().enabled = false;
    }
}
