using System;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject carPrefab;

    private void Awake()
    {
        var car = Instantiate(carPrefab);
        car.transform.position = new Vector3(0, 1.8f, 0);
        car.GetComponent<CarMovement>().enabled = false;
    }
}
