using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D my_rigidbody2D;
    private Animator my_animator;
    [SerializeField] private float speed = 15f;

    private void Start()
    {
        this.my_rigidbody2D = this.GetComponent<Rigidbody2D>();
        this.my_animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 movementVector = new Vector2();
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");


        my_rigidbody2D.velocity = movementVector.normalized * speed;

        //get angle of movement angle if up is 0 degrees
        float angle = Mathf.Atan2(my_rigidbody2D.velocity.y, my_rigidbody2D.velocity.x) * Mathf.Rad2Deg;
        
        //Work in progress
        if(my_rigidbody2D.velocity.magnitude >= 0.01)
        {
            if(angle < -40  && angle > -140)
            {
                my_animator.SetTrigger("isRunningDown");
            }
            else if(angle > 40 && angle < 140)
            {
                my_animator.SetTrigger("isRunningUp");
            }
            else
            {
                my_animator.SetTrigger("isRunningHorizontal");
            }
        }
    }
}
