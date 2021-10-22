using System;
using UnityEngine;

public class CarTakeDamage : MonoBehaviour
{
    private const int MaxDamage = 500;
    private CarMovement carMovement;

    private void Awake()
    {
        carMovement = GameObject.FindObjectOfType<CarMovement>();
    }

    public void TakeDamage(CarController car)
    {
        Debug.Log("Vertical speed: " + carMovement.Vertical);
        car.Health -= Math.Abs((int)Math.Round(MaxDamage * carMovement.Vertical));
        
        Debug.Log("I'm taking damaageeeee!");
    }

    public void DealDamage()
    {
        //Deal Damage with car
    }
}
