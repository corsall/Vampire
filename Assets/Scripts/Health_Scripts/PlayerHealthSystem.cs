using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    public override float Health { get; protected set; }  = 100f;
    public override float HealthMax { get; protected set; } = 100f;

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
