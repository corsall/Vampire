using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackOnCollision : MonoBehaviour
{
    private HealthSystem playerHealth;
    [SerializeField] private float damage = 10f;
    private string objectTag;
    // Start is called before the first frame update
    void Start()
    {
        this.playerHealth = GameObject.FindWithTag("Player").GetComponent<HealthSystem>();
        this.objectTag = this.gameObject.tag;
    }

    // Damage checks
    void OnTriggerEnter2D(Collider2D collision)
    {
        if((this.objectTag == "Enemy" || this.objectTag == "Enemy Weapon") && collision.gameObject.tag == "Player")
        {
            Attack(playerHealth, collision);
        }
        else if((this.objectTag == "Enemy" || this.objectTag == "Enemy Weapon") && collision.gameObject.tag == "Ally")
        {
            Attack(collision.gameObject.GetComponent<HealthSystem>(), collision);
        }
        else if ((this.objectTag == "Ally" || this.objectTag == "Ally Weapon") && collision.gameObject.tag == "Enemy")
        {
            Attack(collision.gameObject.GetComponent<HealthSystem>(), collision);
        }
    }

    protected virtual void Attack(HealthSystem healthSystem, Collider2D collision)
    {
        healthSystem.Damage(damage);
    }
}
