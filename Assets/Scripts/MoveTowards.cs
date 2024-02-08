using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private float force = 20.0f;
    [SerializeField] private float maxSpeed = 5.0f;

    void Start()
    {   
        player = GameObject.FindWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();

        this.GetComponent<Rigidbody2D>().freezeRotation = true;

        ConfigureRigidBody();
    }


    void FixedUpdate()
    {
        Vector3 directionToPlayer = (player.transform.position - this.transform.position).normalized;
        Vector2 velocityToAchieve = directionToPlayer * maxSpeed;

        //List<GameObject> nearestObjects = GetNearestObjects(this.transform.position, radius);

        ////Apply force to move this object from other objects
        //foreach (GameObject obj in nearestObjects)
        //{
        //    if (obj != this.gameObject)
        //    {
        //        Vector3 directionToObject = (obj.transform.position - this.transform.position).normalized;
        //        Vector2 forceToApply = directionToObject * crowdForce;
        //        rb.AddForce(-forceToApply);
        //    }
        //}


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
