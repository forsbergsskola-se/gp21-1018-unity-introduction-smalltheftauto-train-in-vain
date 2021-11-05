using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pedestrian : Entity, IDamageable
{
    public int MoveSpeed;
    public int WaitTimeMax;
    public int WaitTimeMin;
    public int PanicModeTime;
    
    private bool somethingIsInFrontfMeOhNo;
    private bool inPanicMode;
    private bool walkBackwards;
    private bool walk;
    private float panicModeTimeOffset = 1;
    private float panicModeSpeedOffset = 1;
    private void Update()
    {
        // RandomMovement();
        if (walk)
            transform.Translate(Vector3.up * (MoveSpeed * panicModeSpeedOffset)* Time.deltaTime);
        if (walkBackwards)
            transform.Translate(Vector3.down * (MoveSpeed/2 * panicModeSpeedOffset) * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        walk = false;
        somethingIsInFrontfMeOhNo = true;
        walkBackwards = true;
        Invoke("WalkBackwards", 1 * panicModeTimeOffset);
        // transform.Rotate(Vector3.forward * 180);

    }

    private void Start()
    {
        Turn();
    }

    void WalkBackwards()
    {
        walkBackwards = false;
        somethingIsInFrontfMeOhNo = false;
        Invoke("Turn", Random.Range(WaitTimeMin, WaitTimeMax) * panicModeTimeOffset);
    }

    void Walk()
    {
        if (!somethingIsInFrontfMeOhNo)
        {
            walk = false;
            Invoke("Turn", Random.Range(WaitTimeMin, WaitTimeMax) * panicModeTimeOffset);
        }
    }

    void Turn()
    {
        if (!somethingIsInFrontfMeOhNo)
        {
            transform.Rotate(Vector3.forward * Random.Range(0, 360));
            walk = true;
            Invoke("Walk", Random.Range(WaitTimeMin, WaitTimeMax) * panicModeTimeOffset);
        }
    }


    public override void TakeDamage(int value, GameObject attacker = null)
    {
        if (attacker.TryGetComponent(out TAG_CollisionDamage noUseCase))
        {
            Debug.Log("NPC got run over!");
            value *= 5;
        }

        if (attacker.TryGetComponent(out TAG_WaterDamage noUseCase2))
        {
            value *= 10;
        }

        StartCoroutine(PanicMode());
        base.TakeDamage(value, attacker);
    }

    IEnumerator PanicMode()
    {
        inPanicMode = true;
        panicModeSpeedOffset = 7;
        panicModeTimeOffset = 0.5f;
        yield return new WaitForSeconds(PanicModeTime);
        panicModeSpeedOffset = 1;
        panicModeTimeOffset = 1;
        inPanicMode = false;
    }

    public override void OnDeath()
    {
        FindObjectOfType<GameController>().AddMoney(75);
        FindObjectOfType<MoneySpawner>().SpawnMoney50(gameObject.transform.position);
        FindObjectOfType<GameController>().AddScore(150);
        base.OnDeath();
    }
}