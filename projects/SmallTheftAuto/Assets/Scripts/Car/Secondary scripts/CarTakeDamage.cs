using System;
using UnityEngine;

public class CarTakeDamage : MonoBehaviour
{
    private const int MaxDamage = 500;
    private CarMovement carMovement;

    private void Awake()
    {
        carMovement = GetComponent<CarMovement>();
    }

    public void TakeDamage(CarController car)
    {
        car.Health -= Math.Abs((int)Math.Round(MaxDamage * carMovement.Vertical));
    }

    public void DealDamage()
    {
        //Deal Damage with car
    }
}
