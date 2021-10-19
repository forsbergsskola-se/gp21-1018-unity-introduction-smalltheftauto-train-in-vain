using System;
using UnityEngine;

public class PlayerDrive : MonoBehaviour
{
    private const float RangeToGetIn = 10f;
    private const KeyCode VehicleInteract = KeyCode.F;
    public GameObject Car;

    void Update()
    {
        if (isWithinRange() && Input.GetKeyDown(VehicleInteract))
        {
            EnterVehicle();
        }
    }
    
    private void EnterVehicle()
    {
        gameObject.SetActive(false);
    }

    private bool isWithinRange()
    {
        return Vector3.Distance(gameObject.transform.position, Car.gameObject.transform.position) <= RangeToGetIn;
    }
}
