using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerDrive : MonoBehaviour
{
    private const float RangeToGetIn = 5f;
    private const KeyCode VehicleInteract = KeyCode.F;
    public List<GameObject> carsInScene;
    private GameObject targetCar;

    private void Start()
    {
        // carsInScene = GameObject.FindGameObjectsWithTag("Car").ToList();
    }

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
        var length = carsInScene.Count;
        for (var i = 0; i < length; i++)
        {
            result = Vector3.Distance(gameObject.transform.position, carsInScene[i].gameObject.transform.position) <= RangeToGetIn;
            if (result)
            {
                targetCar = carsInScene[i];
                break;
            }
        }
        return result;
    }
}
