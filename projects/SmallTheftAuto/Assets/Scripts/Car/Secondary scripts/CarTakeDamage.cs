using System;
using UnityEngine;

public class CarTakeDamage : MonoBehaviour
{
    private CarMovement carMovement;

    private void Awake()
    {
        carMovement = GameObject.FindObjectOfType<CarMovement>();
    }

    public void TakeDamage(CarController car, int damage)
    {
        Debug.Log("Vertical speed: " + carMovement.VerticalSpeed);
        car.Health -= (int)Math.Round(damage * carMovement.VerticalSpeed);
        Debug.Log("I'm dealing damaageeeee!");
    }

    public void DealDamage()
    {
        //Deal Damage with car
    }
}
