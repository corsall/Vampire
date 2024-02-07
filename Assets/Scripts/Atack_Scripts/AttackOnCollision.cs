using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class AttackOnCollision : MonoBehaviour
{
    private HealthSystem playerHealth;
    private string objectTag;

    // Don't forget to call base.Start() in the derived class
    protected virtual void Start()
    {
        this.playerHealth = GameObject.FindWithTag("Player").GetComponent<HealthSystem>();
        this.objectTag = this.gameObject.tag;
    }

    // Damage checks
    private void OnTriggerStay2D(Collider2D collision)
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

    /// <summary>
    /// Implement the attack logic in the derived class
    /// </summary>
    /// <param name="healthSystem">The health system of the object being attacked</param>
    /// <param name="collision">The collider of the object being attacked</param>
    abstract protected void Attack(HealthSystem healthSystem, Collider2D collision);
}
