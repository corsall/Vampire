using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    [SerializeField] private float invisTime = 0.5f;
    private float lastDamegeTime = 0f;

    public override void Damage(float damageAmount)
    {
        if (Time.time - lastDamegeTime >= invisTime)
        {
            base.Damage(damageAmount);
            lastDamegeTime = Time.time;
        }
    }   
}
