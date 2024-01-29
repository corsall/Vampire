using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnHealthChanged;

    [SerializeField] private float health = 100f;
    [SerializeField] private float healthMax = 100f;

    public float GetHealth()
    {
        return health;
    }

    public float GetHealthPercent()
    {
        return (health / healthMax) * 100f;
    }

    public virtual void Damage(float damageAmount)
    {
        health -= damageAmount;
        if (health < 0)
        {
            health = 0;
        }
        if(health == 0 && this.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
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
