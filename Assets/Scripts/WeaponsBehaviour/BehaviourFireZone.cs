using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BehaviourFireZone : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float radius = 4.0f;
    private Vector3 currentPlayerPosition;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        this.currentPlayerPosition = player.transform.position;

        RotateTowardsPlayer();
        RotateTowardsMouseOrbitally();
    }

    void RotateTowardsPlayer()
    {
        Vector3 dirrection = (currentPlayerPosition - this.transform.position).normalized;

        float angle_towards_player = Mathf.Atan2(dirrection.y, dirrection.x) * Mathf.Rad2Deg + 90;

        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle_towards_player));
    }

    /// <summary>
    /// Rotate object orbitally by some angle. Current object will be rotated around player
    /// </summary>
    /// <param name="angle"></param>
    void RotateOrbitallyByAngle(float angle)
    {
        float radian = angle / Mathf.Rad2Deg;
        float offsetX = Mathf.Sin(radian);
        float offsetY = Mathf.Cos(radian);


        Vector3 OrbitalPosition = new Vector3(currentPlayerPosition.x + radius * offsetX, currentPlayerPosition.y + radius * offsetY, currentPlayerPosition.z);

        this.transform.position = OrbitalPosition;
    }

    void RotateTowardsMouseOrbitally()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseToPlayerVector = currentPlayerPosition - mousePos;

        float angle = Mathf.Atan2(mouseToPlayerVector.y, mouseToPlayerVector.x) * Mathf.Rad2Deg * -1 - 90;
        RotateOrbitallyByAngle(angle);
    }
}
