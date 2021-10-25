using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentDamage : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        var environmentDamage = other.GetComponent<PlayerHealth>();
        environmentDamage.TakeDamage(1);
    }
}
