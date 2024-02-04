using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BehaviourFireZone : MonoBehaviour
{
    private GameObject player;
    //[SerializeField] private float radius = 8.0f;
    [SerializeField] private float orbitalSpeed = 1.0f;
    [SerializeField] private float radius = 3.0f;
    private Vector3 currentPlayerPosition;

    [SerializeField]
    [Range(0, 1)]
    float t = 0;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.currentPlayerPosition = player.transform.position;

        RotateTowardsPlayer();
        Debug.Log(Time.time);
    }

    void RotateTowardsPlayer()
    {
        Vector3 dirrection = (currentPlayerPosition - this.transform.position).normalized;

        float angle_towards_player = Mathf.Atan2(dirrection.y, dirrection.x) * Mathf.Rad2Deg + 90;

        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle_towards_player));
    }

    void RotateOrbitally(float radian)
    {
        float offsetX = Mathf.Sin(radian);
        float offsetY = Mathf.Cos(radian);


        Vector3 OrbitalPosition = new Vector3(currentPlayerPosition.x + radius * offsetX, currentPlayerPosition.y + radius * offsetY, currentPlayerPosition.z);

        this.transform.position = OrbitalPosition;
    }
}
