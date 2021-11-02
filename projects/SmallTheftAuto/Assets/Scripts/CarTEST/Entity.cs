using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public int MaxHealth;
    
    private int health;
    
    public bool IsAlive => health > 0;
    public bool IsDead => !IsAlive;

    public int Health
    {
        get => health;
        protected set => health = Mathf.Clamp(value, 0, MaxHealth);
    }

    // TODO: Possibly add a invulnerability time.
    public virtual void TakeDamage(int value) => Health -= value;
}