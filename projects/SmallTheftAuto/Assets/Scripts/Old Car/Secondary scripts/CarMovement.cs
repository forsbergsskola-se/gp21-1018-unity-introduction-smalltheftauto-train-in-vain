using System;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float maxSpeed = 30f;
    public float turnSpeed = 150f;

    // Used to scale damage in collisions.V
    public float Vertical { get; set; }

    void Update()
    {
        Vertical = Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
        var horizontal = Input.GetAxis("Horizontal") * (turnSpeed + Vertical) * Time.deltaTime;
        
        if (Vertical != 0) {
            transform.Rotate(0, 0, - horizontal);
        }
        if (Vertical < 0) {
            transform.Translate(0, Vertical / 2, 0 );
        }
        
        else {
            transform.Translate(0,Vertical ,0 );
        }
    }
}
