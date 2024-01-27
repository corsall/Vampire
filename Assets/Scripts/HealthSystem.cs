using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnHealthChanged;

    [SerializeField] private float health = 100f;
    [SerializeField] private float healthMax = 100f;

    public HealthSystem(float healthMax)
    {
        this.healthMax = healthMax;
        this.health = healthMax;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetHealthPercent()
    {
        return health / healthMax * 100f;
    }

    public void Damage(float damageAmount)
    {
        Debug.Log("Damage: " + damageAmount);
        health -= damageAmount;
        if (health < 0)
        {
            health = 0;
        }
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
        if (health > healthMax)
        {
            health = healthMax;
        }
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }
}
