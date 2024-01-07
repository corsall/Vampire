using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    Vector3 movementVector;

    [SerializeField] float speed = 2f;
    private void MovemnentSets()
    {
        rb = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
    }

    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        movementVector *= speed;
        rb.velocity = movementVector;  
    }
}
