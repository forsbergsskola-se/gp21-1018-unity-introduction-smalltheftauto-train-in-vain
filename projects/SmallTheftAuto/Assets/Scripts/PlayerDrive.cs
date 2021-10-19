using UnityEngine;

public class PlayerDrive : MonoBehaviour
{
    private const float RangeToGetIn = 10f;
    private const KeyCode VehicleInteract = KeyCode.F;
    public GameObject Car;

    void Update()
    {
        if (gameObject.activeInHierarchy && isWithinRange() && Input.GetKeyDown(VehicleInteract))
        {
            EnterVehicle();
        }
    }
    
    private void EnterVehicle()
    {
        Car.gameObject.GetComponent<HandlePassenger>().Enter();
    }

    private bool isWithinRange()
    {
        return Vector3.Distance(gameObject.transform.position, Car.gameObject.transform.position) <= RangeToGetIn;
    }
}
