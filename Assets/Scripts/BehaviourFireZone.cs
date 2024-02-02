using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourFireZone : MonoBehaviour
{
    private GameObject player;
    //[SerializeField] private float radius = 8.0f;
    [SerializeField] private float orbitalSpeed = 1.0f;
    [SerializeField] private float radius = 3.0f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Знаходжу позицію гравця в даний момент часу
        Vector3 currentPlayerPosition = player.transform.position;

        //Кручу об'єкт за певною орбітою в часі
        UpdateOrbitalPosition(currentPlayerPosition);

        Vector2 direction = (Vector2)currentPlayerPosition - (Vector2)this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        this.transform.rotation = rotation;
    }

    void UpdateOrbitalPosition(Vector3 currentPlayerPosition)
    {
        float offsetX = Mathf.Sin(Time.time * orbitalSpeed);
        float offsetY = Mathf.Cos(Time.time * orbitalSpeed);

        Vector3 OrbitalPosition = new Vector3(currentPlayerPosition.x + radius * offsetX, currentPlayerPosition.y + radius * offsetY, currentPlayerPosition.z);

        this.transform.position = OrbitalPosition;
    }
}
