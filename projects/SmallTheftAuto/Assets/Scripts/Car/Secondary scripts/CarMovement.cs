using System;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float maxSpeed = 30f;
    public float turnSpeed = 150f;

    public float VerticalSpeed { get; set; }

    void Update()
    {
        VerticalSpeed = Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
        var horizontalSpeed = Input.GetAxis("Horizontal") * (turnSpeed + VerticalSpeed) * Time.deltaTime;

        if (VerticalSpeed != 0) {
            transform.Rotate(0, 0, - horizontalSpeed);
        }

        if (VerticalSpeed < 0) {
            transform.Translate(0, VerticalSpeed/ 2, 0 );
        }

        else {
            transform.Translate(0,VerticalSpeed ,0 );
        }
    }
}
