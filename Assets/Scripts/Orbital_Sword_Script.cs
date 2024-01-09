using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Orbital_Sword_Script : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float radius = 8.0f;
    [SerializeField] private float rotationSpeed = 450.0f;
    [SerializeField] private float orbitalSpeed = 2.0f;

    void Start()
    {
        //Знаходжу об'єкт гравця
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //Знаходжу позицію гравця в даний момент часу
        Vector3 currentPlayerPosition = player.transform.position;

        //Кручу об'єкт за певною орбітою в часі
        UpdateOrbitalPosition(currentPlayerPosition);

        //Задаю в часі крутіння меча
        UpdateSwordRotation();
    }

    void UpdateOrbitalPosition(Vector3 currentPlayerPosition)
    {
        float offsetX = Mathf.Sin(Time.time * orbitalSpeed);
        float offsetY = Mathf.Cos(Time.time * orbitalSpeed);

        Vector3 OrbitalPosition = new Vector3(currentPlayerPosition.x + radius * offsetX, currentPlayerPosition.y + radius * offsetY, currentPlayerPosition.z);

        this.transform.position = OrbitalPosition;
    }

    void UpdateSwordRotation()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -Time.time * rotationSpeed));
    }
}
