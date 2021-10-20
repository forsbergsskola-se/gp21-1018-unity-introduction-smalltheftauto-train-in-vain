using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
  
    
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            spriteRenderer.sprite = sprite1;
        }
        
        if (Input.GetKeyDown("2"))
        {
            spriteRenderer.sprite = sprite2;
        }
        
        if (Input.GetKeyDown("3"))
        {
            spriteRenderer.sprite = sprite3;
        }
        
        if (Input.GetKeyDown("4"))
        {
            spriteRenderer.sprite = sprite4;
        }
        
        if (Input.GetKeyDown("5"))
        {
            spriteRenderer.sprite = sprite5;
        }
        
        if (Input.GetKeyDown("6"))
        {
            spriteRenderer.sprite = sprite6;
        }
    }
}
