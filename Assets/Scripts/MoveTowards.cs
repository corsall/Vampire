using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private float force = 5.0f;
    [SerializeField] private float maxSpeed = 5.0f;
    [SerializeField] private float drag = 5.0f;

    void Start()
    {   
        player = GameObject.FindWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();

        ConfigureRigidBody();
    }


    void FixedUpdate()
    {

        //This is too slow
        //Vector3 directionToPlayer = (player.transform.position - this.transform.position).normalized;
        //Vector2 velocityToAchieve = directionToPlayer * maxSpeed;

        //if (rb.velocity.magnitude < maxSpeed)
        //{
        //    rb.AddForce(directionToPlayer * force);
        //}
        //else
        //{
        //    //Friction force appears to stop the object
        //    //Also to stop wobliness of the object toStopRotation Vector is added
        //    Vector2 friction = rb.velocity.normalized * -force;
        //    Vector2 toStopRotation = (rb.mass * (-rb.velocity / Time.fixedDeltaTime) + (rb.mass * (velocityToAchieve / Time.fixedDeltaTime))).normalized * force;
        //    rb.AddForce(friction + toStopRotation);
        //    Debug.DrawRay(this.transform.position, toStopRotation, Color.white);
        //}

        //Test
        Vector3 directionToPlayer = (player.transform.position - this.transform.position).normalized;

        if(rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(directionToPlayer * force, ForceMode2D.Impulse);
        }
    }

    private void ConfigureRigidBody()
    {
        rb.gravityScale = 0;
        rb.drag = this.drag;
        rb.freezeRotation = true;
    }

    public List<GameObject> GetNearestObjects(Vector3 position, float maxRange)
    {
        GameObject[] crowd = GameObject.FindGameObjectsWithTag(tag);
        List<GameObject> nearestCrowd = new List<GameObject>();
        if (crowd == null)
        {
            return null;
        }
        foreach (GameObject obj in crowd)
        {
            if (Vector3.Distance(obj.transform.position, position) <= maxRange)
            {
                nearestCrowd.Add(obj);
            }
        }
        return nearestCrowd;
    }
}
