using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerDrive : MonoBehaviour
{
    private const float RangeToGetIn = 10f;
    private const KeyCode VehicleInteract = KeyCode.F;
    private List<GameObject> carsInScene;
    private GameObject targetCar;

    private void Start()
    {
        carsInScene = GameObject.FindGameObjectsWithTag("Car").ToList();
    }

    void Update()
    {
        if (gameObject.activeInHierarchy && carIsWithinRange() && Input.GetKeyDown(VehicleInteract))
        {
            EnterVehicle();
            targetCar = null;
        }
    }
    
    private void EnterVehicle()
    {
        targetCar.GetComponent<HandlePassenger>().Enter();
    }

    private bool carIsWithinRange()
    {
        var result = false;
        var length = carsInScene.Count;
        for (var i = 0; i < length; i++)
        {
            result = Vector3.Distance(gameObject.transform.position, carsInScene[i].gameObject.transform.position) <= RangeToGetIn;
            if (!result) continue;
            targetCar = carsInScene[i].gameObject;
            break;
        }
        return result;
    }
}
