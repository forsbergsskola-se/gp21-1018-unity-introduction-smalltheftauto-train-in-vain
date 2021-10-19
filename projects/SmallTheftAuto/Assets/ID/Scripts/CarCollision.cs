using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("CarID")&& Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            
        }
    }
}
