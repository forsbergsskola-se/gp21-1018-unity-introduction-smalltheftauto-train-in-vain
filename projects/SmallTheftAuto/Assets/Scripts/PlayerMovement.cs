using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotSpeed = 120f;
    public float speed = 20f;
    void Start()
    {
        
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * rotSpeed* Time.deltaTime;
        var vertical = Input.GetAxis("Vertical") * speed*Time.deltaTime;
        transform.Translate(0,vertical,0 );
        transform.Rotate(0, 0, -horizontal);
    }
}
