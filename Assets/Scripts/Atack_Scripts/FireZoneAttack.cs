using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZoneAttack : AttackOnCollision
{
    [SerializeField] private float knockback = 5f;
    [SerializeField] private float knockbackTime = 0.5f;
    GameObject player;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player");
    }

    protected override void Attack(HealthSystem healthSystem, Collider2D collision)
    {
        Rigidbody2D rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();

        if (rigidbody2D != null)
        {
            StartCoroutine(ApplyKnockback(rigidbody2D));
        }
    }

    // Coroutine to gradually apply knockback force over time
    IEnumerator ApplyKnockback(Rigidbody2D rigidbody2D)
    {
        //GameObject player = GameObject.FindWithTag("Player");
        Vector2 direction = (this.transform.position - player.transform.position).normalized;

        float knockbackTimer = 0f;

        while (knockbackTimer < knockbackTime)
        {

            if (rigidbody2D == null)
            {
                yield break; // Exit the coroutine if the Rigidbody2D is null
            }
            rigidbody2D.AddForce(direction * knockback);
            knockbackTimer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
