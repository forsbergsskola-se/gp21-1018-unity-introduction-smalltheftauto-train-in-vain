using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollisionID : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Car")&& Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            
        }
    }
}
