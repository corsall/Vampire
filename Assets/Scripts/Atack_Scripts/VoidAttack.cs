using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidAttack : AttackOnCollision
{
    [SerializeField] private float gravityForce = 5f;
    [SerializeField] private float gravityTime = 0.5f;
    [SerializeField] private float damage = 1000f;
    [SerializeField] private float atackRadius = 2f;
    //private float coliderRadius;
    GameObject player;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player");
        //coliderRadius = this.GetComponent<CircleCollider2D>().radius;
    }

    protected override void Attack(HealthSystem healthSystem, Collider2D collision)
    {
        Rigidbody2D rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();

        if (rigidbody2D != null)
        {
            StartCoroutine(ApplyGravity(rigidbody2D));
        }

        float distanceToObject = Vector2.Distance(this.transform.position, collision.transform.position);
        if (distanceToObject < atackRadius)
        {
            healthSystem.Damage(damage);
        }
    }

    IEnumerator ApplyGravity(Rigidbody2D rigidbody2D)
    {
        Vector2 direction = (this.transform.position - rigidbody2D.transform.position).normalized;
        Vector2 directionNormalized = direction.normalized;

        //float t = (coliderRadius - direction.magnitude)/ coliderRadius;

        float gravityTimer = 0f;

        while (gravityTimer < gravityTime)
        {

            if (rigidbody2D == null)
            {
                yield break; // Exit the coroutine if the Rigidbody2D is null
            }
            rigidbody2D.AddForce(directionNormalized * gravityForce);

            gravityTimer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
