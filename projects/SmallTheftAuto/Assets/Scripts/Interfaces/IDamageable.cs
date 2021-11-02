using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IDamageable
{
    public void TakeDamage(int value, GameObject attacker);
}
