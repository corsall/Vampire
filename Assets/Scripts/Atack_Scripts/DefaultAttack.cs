using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAttack : AttackOnCollision
{
    [SerializeField] private float damage = 10f;

    protected override void Attack(HealthSystem healthSystem, Collider2D collision)
    {
        healthSystem.Damage(damage);
    }
}
