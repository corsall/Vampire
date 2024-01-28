using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSwordAttack : AttackOnCollision
{
    [SerializeField] private float knockback = 100f;
    [SerializeField] private float knockbackTime = 2f;

    protected override void Attack(HealthSystem healthSystem, Collider2D collision)
    {
        base.Attack(healthSystem, collision);

        Rigidbody2D rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();

        if (rigidbody2D != null)
        {
            StartCoroutine(ApplyKnockback(rigidbody2D));
        }
    }

    // Coroutine to gradually apply knockback force over time
    IEnumerator ApplyKnockback(Rigidbody2D rigidbody2D)
    {
        float knockbackTimer = 0f;

        while (knockbackTimer < knockbackTime)
        {

            if (rigidbody2D == null)
            {
                yield break; // Exit the coroutine if the Rigidbody2D is null
            }
            rigidbody2D.AddForce(new Vector2(knockback, 0));
            knockbackTimer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
