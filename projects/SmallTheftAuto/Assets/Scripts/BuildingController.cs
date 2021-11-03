using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : Entity, IDamageable
{
    void TakeDamage(int value, GameObject attacker)
    {
        if (attacker.TryGetComponent(out TAG_BulletDamage noUseCase))
        {
            Debug.Log("The buildings thick walls reduces the impact of the bullet.!");
            value /= 3;
        }
        if (attacker.TryGetComponent(out TAG_CollisionDamage noUseCase2))
        {
            Debug.Log("The buildings strength reduces the damage of the collision!");
            value /= 2;
        }
        base.TakeDamage(value, attacker);
    }
}
