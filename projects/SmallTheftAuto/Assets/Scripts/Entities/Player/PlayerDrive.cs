using System.Collections.Generic;
using UnityEngine;

public class PlayerDrive : MonoBehaviour
{
    // private const float RangeToGetIn = 5f;
    // private const KeyCode VehicleInteract = KeyCode.F;
    // public List<GameObject> carsInScene;
    // private GameObject targetCar;

    // Currently in the new Update()
    // void Update()
    // {
    //     if (gameObject.activeInHierarchy && carIsWithinRange() && Input.GetKeyDown(VehicleInteract))
    //     {
    //         EnterVehicle();
    //     }
    // }
    
    // private void EnterVehicle()
    // {
    //     targetCar.GetComponent<HandlePassenger>().EnterCar();
    // }
    //
    // private bool carIsWithinRange()
    // {
    //     var result = false;
    //     foreach (var car in carsInScene)
    //     {
    //         result = Vector3.Distance(gameObject.transform.position, car.gameObject.transform.position) <= RangeToGetIn;
    //         if (!result) continue;
    //         targetCar = car;
    //         break;
    //     }
    //     return result;
    // }


    public List<GameObject> Enterables;
    private const KeyCode InteractKey = KeyCode.F;
    private GameObject SelectedEnterable;
    public float InterractRange = 5f;
    void Update()
    {
        
        if (gameObject.activeInHierarchy && EnterableInRange() && Input.GetKeyDown(InteractKey))
        {
            SelectedEnterable.GetComponent<IEnterable>().Enter(gameObject);
            SelectedEnterable = null;
        }
    }
    
    bool EnterableInRange()
    {
        foreach (var Enterable in Enterables)
        {
            if (Vector3.Distance(gameObject.transform.position, Enterable.gameObject.transform.position) <=
                InterractRange)
            {
                SelectedEnterable = Enterable;
                return true;
            }
        }
        return false;
    }
}
