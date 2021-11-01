using System;
using UnityEngine;

public class CarTakeDamage : MonoBehaviour, ITarget
{
    private const int MaxDamage = 500;
    private CarMovement carMovement;
    private CarController carController;

    private void Awake()
    {
        carMovement = GetComponent<CarMovement>();
        carController = GetComponent<CarController>();
    }

    public void TakeDamage()
    {
        carController.Health -= Math.Abs((int)Math.Round(MaxDamage * carMovement.Vertical));
    }

    public void TakeDamage(int damage)
    {
        carController.Health -= damage;
    }

    public void DealDamage()
    {
        //Deal Damage with car
    }
}
