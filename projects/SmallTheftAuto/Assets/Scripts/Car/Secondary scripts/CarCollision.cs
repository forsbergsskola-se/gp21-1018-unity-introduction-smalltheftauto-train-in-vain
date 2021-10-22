using System;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    /// <summary>
    /// The script is in charge of detecting CarPrefab's collision
    /// Currently only detecting collision against other cars
    /// </summary>

    private CarController carController;

    private void Awake()
    {
        carController = GameObject.FindObjectOfType<CarController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Car")) return;
        carController.OnCarCollideAgainstCar();
    }
}
