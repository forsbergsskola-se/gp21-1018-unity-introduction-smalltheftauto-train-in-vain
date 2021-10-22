using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotSpeed = 120f;
    public float speed = 10f;

     void Start()
     {
         GetComponent<Animator>().enabled = false;
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
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0,vertical*1,0);
            }
        }


        if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W
        )))
        {
            GetComponent<Animator>().enabled = true;
        }
    }
}
