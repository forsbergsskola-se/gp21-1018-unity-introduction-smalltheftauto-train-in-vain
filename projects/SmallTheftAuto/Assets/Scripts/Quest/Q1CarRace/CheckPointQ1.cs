using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointQ1 : MonoBehaviour
{
    private GameObject questCarCollider;

    private void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject== questCarCollider)
        {
            Debug.Log("hej");
        }
    }
}
