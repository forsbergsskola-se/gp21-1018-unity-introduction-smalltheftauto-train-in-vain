using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotSpeed = 120f;
    public float speed = 10f;
    public bool isWalking;
    public bool isShooting;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Sprite defaultSprite;

    
    void Start()
     {
         spriteRenderer = GetComponent<SpriteRenderer>();
         animator = GetComponent<Animator>();
     }


    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * rotSpeed* Time.deltaTime;
        var vertical = Input.GetAxis("Vertical") * speed*Time.deltaTime;
        transform.Rotate(0, 0, -horizontal);
        
        isWalking = false;
        isShooting = false;
        animator.enabled = false;
        spriteRenderer.sprite = defaultSprite;

        
        if (vertical < 0)
        {
            transform.Translate(0,vertical/2,0);
            isShooting = true;
        }

        else if (isShooting == true)
        {
            PlayerIsShootingPistol();
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
            PlayerIsWalking();
        }

        if (isShooting == true)
        {
            PlayerIsShootingPistol();
        }
    }
     
    
   void PlayerIsWalking()
    {
        if (animator.gameObject.activeSelf)
        {
            animator.enabled = true;
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerWalk");
        }
    }

    void PlayerIsShootingPistol()
    {
        if (animator.gameObject.activeSelf)
        {
            animator.enabled = true;
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerPistolShoot");
        }
    }
}
