using System;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float maxSpeed = 30f;
    public float turnSpeed = 150f;
    private CarController carController;
    private const KeyCode VehicleInteract = KeyCode.F;

    void Update()
    {
        Debug.Log("CarMovement is activated!!");
        if (gameObject.activeInHierarchy && Input.GetKeyDown(VehicleInteract))
        {
            carController.HandlePlayerExitCar();
        }

        var vertical = Input.GetAxis("Vertical") * maxSpeed*Time.deltaTime;
        var horizontal = Input.GetAxis("Horizontal") * (turnSpeed + vertical)* Time.deltaTime;

        if (vertical != 0) {
            transform.Rotate(0, 0, -horizontal);
        }

        if (vertical < 0) {
            transform.Translate(0,vertical/2,0 );
        }

        else {
            transform.Translate(0,vertical,0 );
        }
    }
    
    private void OnEnable()
    {
        Debug.Log("CarMovement enabled!");
        carController = gameObject.GetComponent<CarController>();
    }
}
