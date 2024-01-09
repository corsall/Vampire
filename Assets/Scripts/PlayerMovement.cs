using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D my_rigidbody2D;
    [SerializeField] private float speed = 15f;

    private void Start()
    {
        this.my_rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 movementVector = new Vector2();
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        my_rigidbody2D.velocity = movementVector.normalized * speed;
    }
}
