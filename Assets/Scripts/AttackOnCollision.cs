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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((this.objectTag == "Enemy" || this.objectTag == "Enemy Weapon") && collision.gameObject.tag == "Player")
        {
            playerHealth.Damage(damage);
        }
        else if((this.objectTag == "Enemy" || this.objectTag == "Enemy Weapon") && collision.gameObject.tag == "Ally")
        {
            collision.gameObject.GetComponent<HealthSystem>().Damage(damage);
        }
        else if ((this.objectTag == "Ally" || this.objectTag == "Ally Weapon") && collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<HealthSystem>().Damage(damage);
            Debug.Log(collision.gameObject.GetComponent<HealthSystem>().GetHealth());
        }
    }
}
