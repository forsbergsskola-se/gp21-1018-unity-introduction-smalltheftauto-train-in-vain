using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public static int NextId;

    public int Id;
    
    private void Awake()
    {
        Id = NextId;
        NextId++;
        health = MaxHealth;
    }
    
    public int MaxHealth;

    private int health;
    
    public bool IsAlive => health > 0;
    public bool IsDead => !IsAlive;

    public int Health
    {
        get => health;
        protected set => health = Mathf.Clamp(value, 0, MaxHealth);
    }
    
    
    private bool takeDamageOnCooldown;
    public virtual void TakeDamage(int value, GameObject attacker = null)
    {
        if (!takeDamageOnCooldown)
        {
            Health -= value;
            StartCoroutine(takeDamageCooldown());
        }
    }
    
    IEnumerator takeDamageCooldown()
    {
        takeDamageOnCooldown = true;
        yield return new WaitForSeconds(0.25f);
        takeDamageOnCooldown = false;
    }
}