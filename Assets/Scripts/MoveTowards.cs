using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D my_rigidbody2D;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float radiusToForget = 2f;
    void Start()
    {
        //Знаходжу об'єкт гравця
        player = GameObject.FindWithTag("Player");
        my_rigidbody2D = this.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Вектор від об'єкта що володіє цим класом до гравця
        Vector3 toPlayerVector = player.transform.position - this.transform.position;
        Vector3 toPlayerVectorNormalized = toPlayerVector.normalized;
        if (toPlayerVector.magnitude >= radiusToForget)
        {
            my_rigidbody2D.velocity = toPlayerVectorNormalized * speed;
        }
    }
}
