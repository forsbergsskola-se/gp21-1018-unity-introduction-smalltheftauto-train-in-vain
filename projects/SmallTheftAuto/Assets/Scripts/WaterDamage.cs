using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        var waterDamage = other.GetComponent<PlayerHealth>();
        waterDamage.TakeDamage(1);
    }
}
