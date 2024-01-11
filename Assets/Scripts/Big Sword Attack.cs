using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Big_Sword_Attack : MonoBehaviour
{
    private GameObject player;
    private bool CDStart;
    [SerializeField] private float radius = 0f;
    [SerializeField] private float rotationSpeed = 1000.0f;
    [SerializeField] private float orbitalSpeed = 2.0f;
    [SerializeField] private BigSwordCD cooldown;



    void Start()
    {
        CDStart = cooldown.isCoolingDown;
        CDStart = true;
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
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            cooldown.StartCooldown();

        }
        if (cooldown.isCoolingDown)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            UpdateSwordRotation();
        }
        else 
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

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
        
