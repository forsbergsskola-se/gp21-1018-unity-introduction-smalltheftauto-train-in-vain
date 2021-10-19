using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotSpeed = 120f;
    public float speed = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * rotSpeed* Time.deltaTime;
        var vertical = Input.GetAxis("Vertical") * speed*Time.deltaTime;
        transform.Rotate(0, 0, -horizontal);
        
        if (vertical < 0)
        {
            transform.Translate(0,vertical/2,0);
        }
        else
        {
            transform.Translate(0,vertical,0);
        }
    }
}
// Hello