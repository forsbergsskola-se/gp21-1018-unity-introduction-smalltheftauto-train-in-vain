using System;
using UnityEngine;

public class PlayerMovementISL : MonoBehaviour
{
    public float rotSpeed = 120f;
    public float speed = 20f;

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * rotSpeed* Time.deltaTime;
        var vertical = Input.GetAxis("Vertical") * speed*Time.deltaTime;
        transform.Translate(0,vertical,0 );
        transform.Rotate(0, 0, -horizontal);
    }
}
