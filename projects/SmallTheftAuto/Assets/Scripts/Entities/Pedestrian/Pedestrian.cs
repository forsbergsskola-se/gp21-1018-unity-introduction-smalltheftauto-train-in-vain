using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pedestrian : Entity, IDamageable
{
    public int TurnCooldownMax;
    public int TurnCooldownMin;
    public int MoveSpeed;
    public int WalkDistance;
    public int WaitTimeMax;
    public int WaitTimeMin;



    private bool walk;
    private void Update()
    {
        // RandomMovement();
        if (walk)
            transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);
    }

    private void Start()
    {
        // RandomMovement();
        Turn();
    }


    // void RandomMovement()
    // {
    //     Invoke("RandomMovement", Random.Range(WaitTimeMin, WaitTimeMax));
    //     
    //     if (Random.Range(0, 100) < TurnChance)
    //     {
    //         
    //     }
    // }

    void Walk()
    {
        walk = false;
        Invoke("Turn", Random.Range(WaitTimeMin, WaitTimeMax));
    }

    void Turn()
    {
        transform.Rotate(Vector3.forward * Random.Range(0, 360));
        walk = true;
        Invoke("Walk", Random.Range(WaitTimeMin, WaitTimeMax));
    }


    public override void TakeDamage(int value, GameObject attacker = null)
    {
        if (attacker.TryGetComponent(out TAG_CollisionDamage noUseCase))
        {
            Debug.Log("NPC got run over!");
            value *= 1000;
        }

        if (attacker.TryGetComponent(out TAG_WaterDamage noUseCase2))
        {
            Debug.Log("NPC is taking a swim without knowing how to swim!");
            value *= 10;
        }
        base.TakeDamage(value, attacker);
    }
}
