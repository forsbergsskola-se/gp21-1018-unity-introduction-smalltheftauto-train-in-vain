using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotSpeed = 120f;
    public float speed = 10f;
    public bool isWalking;
    public Sprite defaultSprite;
    public SpriteRenderer spriteRenderer;



     void Start()
     {
         GetComponent<Animator>().enabled = false;
         spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
     }


    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * rotSpeed* Time.deltaTime;
        var vertical = Input.GetAxis("Vertical") * speed*Time.deltaTime;
        transform.Rotate(0, 0, -horizontal);
        isWalking = false;
        GetComponent<Animator>().enabled = false;
        spriteRenderer.sprite = defaultSprite;

        
        if (vertical < 0)
        {
            transform.Translate(0,vertical/2,0);
            isWalking = true;
        }
        else
        {
            transform.Translate(0,vertical,0);
            if (Input.GetKey(KeyCode.W))
            {
                isWalking = true;
            }
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0,vertical*1,0);
                isWalking = true;
            }
        }


        if (isWalking == true)
        {
            GetComponent<Animator>().enabled = true;
        }
    }
}
