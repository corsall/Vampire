using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private float maxSpeed = 5.0f;
    private float force = 20.0f;
    void Start()
    {   
        player = GameObject.FindWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();

        ConfigureRigidBody();
    }


    void FixedUpdate()
    {
        Vector3 directionToPlayer = (player.transform.position - this.transform.position).normalized;
        Vector2 velocityToAchieve = directionToPlayer * maxSpeed;


        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(directionToPlayer * force);
        }
        else
        {
            //Friction force appears to stop the object
            //Also to stop wobliness of the object toStopRotation Vector is added
            Vector2 friction = rb.velocity.normalized * -force;
            Vector2 toStopRotation = (rb.mass * (-rb.velocity / Time.fixedDeltaTime) + (rb.mass * (velocityToAchieve / Time.fixedDeltaTime))).normalized * force;
            rb.AddForce(friction + toStopRotation);
            Debug.DrawRay(this.transform.position, toStopRotation, Color.white);
        }

        //Debug.DrawRay(this.transform.position, rb.totalForce, Color.red);
        //Debug.DrawRay(this.transform.position, rb.velocity, Color.blue);

        //Debug.Log("Speed: " + this.rb.velocity.magnitude + "   Force :" + this.rb.totalForce.magnitude);
    }

    private void ConfigureRigidBody()
    {
        rb.gravityScale = 0;
    }
}
