using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnCollision : MonoBehaviour
{
    private HealthSystem playerHealth;
    [SerializeField] private float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        this.playerHealth = GameObject.FindWithTag("Player").GetComponent<HealthSystem>();
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    playerHealth.Damage(damage);
    //    Debug.Log("Player health: " + playerHealth.GetHealth());
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHealth.Damage(damage);
        Debug.Log("Player health: " + playerHealth.GetHealth());
    }
}
