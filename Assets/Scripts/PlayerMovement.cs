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

        //Work in progress Stupid way to do it
        if (my_rigidbody2D.velocity.magnitude >= 0.01)
        {
            if (angle < -40 && angle > -140)
            {
                my_animator.SetBool("isRunningDown", true);
                my_animator.SetBool("isRunningUp", false);
                my_animator.SetBool("isRunningHorizontal", false);
            }
            else if (angle > 40 && angle < 140)
            {
                my_animator.SetBool("isRunningUp", true);
                my_animator.SetBool("isRunningDown", false);
                my_animator.SetBool("isRunningHorizontal", false);
            }
            else
            {   
                my_animator.SetBool("isRunningHorizontal", true);
                my_animator.SetBool("isRunningUp", false);
                my_animator.SetBool("isRunningDown", false);
            }
        }
    }
}
