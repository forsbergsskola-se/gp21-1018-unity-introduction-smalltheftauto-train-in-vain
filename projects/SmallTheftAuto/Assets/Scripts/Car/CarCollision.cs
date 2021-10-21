using System;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    /// <summary>
    /// The script is in charge of detecting CarPrefab's collision and
    /// the logic connected with it
    /// </summary>
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Car")) return;
        Debug.Log("CAR HIT!!");
    }
}
