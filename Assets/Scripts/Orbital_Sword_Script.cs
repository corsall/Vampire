using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbital_Sword_Script : MonoBehaviour
{
    private GameObject player = null;
    private Vector3 currentPlayerPosition = Vector3.zero;
    public float radius = 10.0f;
    public float rotationSpeed = 450.0f;
    public float orbitalSpeed = 2.0f;

    void Start()
    {
        //Знаходжу об'єкт гравця
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //Знаходжу позицію гравця
        currentPlayerPosition = player.transform.position;

        //Кручу об'єкт за певною орбітою в часі
        gameObject.transform.position = OrbitalRotationPositionInTime();

        //????????????????????????????????????????????????????????????????????????????????
        //Отримую кут між 3 точками
        //Ці три точки це - 1: Статична точка, вершина кола 2: Рухома точка, центр кола (гравець) 3: Рухома точка, сам Меч
        //float angle = CalculateAngleBetweenPoints();

        //Задаю в часі крутіння меча
        gameObject.transform.rotation = SwordRotationInTime();
    }

    //Обрахунок кута між 3 точками в 2D просторі
    //float CalculateAngleBetweenPoints()
    //{
    //    Vector2 point1 = new Vector2(currentPlayerPosition.x, currentPlayerPosition.y + radius);
    //    Vector2 point2 = new Vector2(currentPlayerPosition.x, currentPlayerPosition.y);
    //    Vector2 point3 = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

    //    Vector2 vector1 = point1 - point2;
    //    Vector2 vector2 = point3 - point2;

    //    float crossProduct = vector1.x * vector2.y - vector1.y * vector2.x;

    //    float dotProduct = Vector2.Dot(vector1.normalized, vector2.normalized);

    //    float angleInRadians = Mathf.Acos(dotProduct);

    //    if (crossProduct < 0)
    //    {
    //        angleInRadians = 2 * Mathf.PI - angleInRadians;
    //    }

    //    float angleInDegrees = Mathf.Rad2Deg * angleInRadians;

    //    return angleInDegrees;
    //}

    //Метод обраховує позицію обєкта в якомусь моменті на колі
    Vector3 OrbitalRotationPositionInTime()
    {
        float offsetX = Mathf.Sin(Time.time * orbitalSpeed);
        float offsetY = Mathf.Cos(Time.time * orbitalSpeed);

        Vector3 OrbitalPosition = new Vector3(currentPlayerPosition.x + radius * offsetX, currentPlayerPosition.y + radius * offsetY, currentPlayerPosition.z);

        return OrbitalPosition;
    }

    //Метод обраховує кут об'єкта в часі
    Quaternion SwordRotationInTime()
    {
        return Quaternion.Euler(new Vector3(0, 0, -Time.time * rotationSpeed));
    }
}
