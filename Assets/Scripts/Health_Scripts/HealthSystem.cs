using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnHealthChanged;

    abstract public float Health { get; protected set; }
    abstract public float HealthMax { get; protected set; }

    public float GetHealthPercent()
    {
        return (Health / HealthMax) * 100f;
    }

    public virtual void Damage(float damageAmount)
    {
        Health -= damageAmount;
        if (Health < 0)
        {
            Health = 0;
        }
        if(Health == 0 && this.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }

        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    public virtual void Heal(float healAmount)
    {
        Health += healAmount;
        if (Health > HealthMax)
        {
            Health = HealthMax;
        }

        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }
}
