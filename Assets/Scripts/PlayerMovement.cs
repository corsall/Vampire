using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D my_rigidbody2D;

    [SerializeField] 
    private float speed = 15f;
    private Vector2 movementVector = new Vector2();
    private CustomAnimator animator;

    private void Start()
    {
        this.my_rigidbody2D = this.GetComponent<Rigidbody2D>();
        this.animator = new CustomAnimator(this.GetComponent<Animator>());
    }

    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        float angle = Mathf.Atan2(movementVector.y, movementVector.x) * Mathf.Rad2Deg;

        if (movementVector.x < 0)
        {
            this.transform.localScale = new Vector3(Math.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (movementVector.x > 0)
        {
            this.transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (my_rigidbody2D.velocity.magnitude >= 0.01)
        {
            if (angle < -40 && angle > -140)
            {
                animator.ChangeAnimation("player_movement_down");
            }
            else if (angle > 40 && angle < 140)
            {
                animator.ChangeAnimation("player_movement_up");
            }
            else
            {
                animator.ChangeAnimation("player_movement_horizontal");
            }
        }
        else
        {
            animator.ChangeAnimation("player_idle");
        }
    }

    void FixedUpdate()
    {
        my_rigidbody2D.velocity = movementVector.normalized * speed;
    }
}
