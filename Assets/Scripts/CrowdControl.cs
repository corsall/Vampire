using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdControl : MonoBehaviour
{
    private List<GameObject> crowd;
    [SerializeField] private float crowdForce = 5.0f;
    [SerializeField] private float crowdPushDistance = 2.0f;

    public void FixedUpdate()
    {
        //Apply force onece every 10 frames
        if (Time.frameCount % 10 == 0)
        {
            ApplyForce();
        }
    }

    private void Awake()
    {
        this.crowd = new List<GameObject>();
    }

    public void AddToCrowd(GameObject gameObject)
    {
        this.crowd.Add(gameObject);
    }

    // Find all objects in parrent and update the crowd list
    public void UpdateCrowd()
    {
        this.crowd.Clear();
        foreach (Transform child in transform)
        {
            this.crowd.Add(child.gameObject);
        }
    }

    // Calculate distance between all objects in the crowd

    public void ApplyForce()
    {
        for (int i = 0; i < crowd.Count; i++)
        {
            for (int j = 0; j < crowd.Count; j++)
            {
                if (i != j)
                {
                    Vector3 distance = (crowd[i].transform.position - crowd[j].transform.position);

                    if (distance.magnitude < crowdPushDistance)
                    {
                        Vector2 forceToApply = distance.normalized * crowdForce;
                        crowd[j].GetComponent<Rigidbody2D>().AddForce(-forceToApply);
                    }
                }
            }
        }
    }

}
