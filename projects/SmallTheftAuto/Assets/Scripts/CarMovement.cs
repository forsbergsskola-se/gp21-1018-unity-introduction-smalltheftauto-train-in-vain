using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

public class CarMovement : MonoBehaviour
{
    public float maxSpeed = 30f;
    
    public float turnSpeed = 150f;

    private float speed;
    private const KeyCode VehicleInteract = KeyCode.F;

    void Update()
    {
        // NOTE: Check first if Player wants to exit
        if (Input.GetKeyDown(VehicleInteract))
        {
            gameObject.GetComponent<HandlePassenger>().Exit();
            return;
        }
        
        var vertical = Input.GetAxis("Vertical") * maxSpeed*Time.deltaTime;
        var horizontal = Input.GetAxis("Horizontal") * (turnSpeed + vertical)* Time.deltaTime;

        if (vertical != 0)
        {
            transform.Rotate(0, 0, -horizontal);
        }

        if (vertical < 0)
        {
            transform.Translate(0,vertical/2,0 );
        }

        else
        {
            transform.Translate(0,vertical,0 );
        }
    }
}
