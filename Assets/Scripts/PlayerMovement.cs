using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D my_rigidbody2D;

    [SerializeField] 
    private float speed = 15f;
    private Vector2 movementVector = new Vector2();

    private void Start()
    {
        this.my_rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        my_rigidbody2D.velocity = movementVector.normalized * speed;
    }
}
