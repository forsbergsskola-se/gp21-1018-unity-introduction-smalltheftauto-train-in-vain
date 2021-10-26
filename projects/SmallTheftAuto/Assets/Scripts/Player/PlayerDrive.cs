using System.Collections.Generic;
using UnityEngine;

public class PlayerDrive : MonoBehaviour
{
    private const float RangeToGetIn = 5f;
    private const KeyCode VehicleInteract = KeyCode.F;
    public List<GameObject> carsInScene;
    private GameObject targetCar;

    void Update()
    {
        if (gameObject.activeInHierarchy && carIsWithinRange() && Input.GetKeyDown(VehicleInteract))
        {
            EnterVehicle();
        }
    }
    
    private void EnterVehicle()
    {
        targetCar.GetComponent<HandlePassenger>().EnterCar();
    }

    private bool carIsWithinRange()
    {
        var result = false;
        foreach (var car in carsInScene)
        {
            result = Vector3.Distance(gameObject.transform.position, car.gameObject.transform.position) <= RangeToGetIn;
            if (!result) continue;
            targetCar = car;
            break;
        }
        return result;
    }
}
