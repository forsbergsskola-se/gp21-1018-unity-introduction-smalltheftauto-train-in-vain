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

    // Update is called once per frame
    void Update()
    {
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





        // transform.Translate(0f, acceleration*Time.deltaTime*Input.GetAxis("Vertical"), 0f);
        // transform.Rotate(0f, 0f, turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        //
        // var horizontal = Input.GetAxis("Horizontal");
        // var vertical = Input.GetAxis("Vertical");
        
        // rigidbody2D.velocity = horizontal, vertical;

        // if (vertical != null)
        // {
        //     // Rotate the car if needed.
        //     transform.Rotate(0f, 0f, turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        //     
        //     // Check if speed is increased.
        // }
        //
        // // If nothing is being input.
        // if (speed != 0)
        // {
        //     transform.Translate(0f, speed * Time.deltaTime, 0f);
        //     // speed = math.min(speed, math.abs(deAcceleration));
        // }
        

        // rigidbody2D.velocity = (transform.forward * vertical) * Time.fixedDeltaTime;
        // transform.Rotate((transform.up * horizontal) * turnSpeed * Time.fixedDeltaTime);
        //
        // rigidbody2D.velocity = math.max(acceleration * Input.GetAxis("Vertical") * Time.deltaTime, maxSpeed);
    }
}
