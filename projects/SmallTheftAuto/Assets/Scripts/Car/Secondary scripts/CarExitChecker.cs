using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarExitChecker : MonoBehaviour
{
    public HandlePassenger HandlePassenger;
    
    private const KeyCode VehicleInteractKey = KeyCode.F;
    

    
    void Update()
    {
        if (gameObject.activeInHierarchy && Input.GetKeyDown(VehicleInteractKey))
        {
            HandlePassenger.ExitCar();
        }
    }
}
