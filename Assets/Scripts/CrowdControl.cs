using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdControl : MonoBehaviour
{
    private static List<GameObject> crowd;

    private void Start()
    {
        crowd = new List<GameObject>();
    }

    public void AddToCrowd(GameObject gameObject)
    {
        crowd.Add(gameObject);
    }

    // Find all objects for the crowd by tag
    public void AddToCrowdByTag(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objects)
        {
            crowd.Add(obj);
        }
    }

    // For specified position and max range , find all objects for the crowd GET
    public List<GameObject> AddToCrowdByPosition(Vector3 position, float maxRange)
    {
        List<GameObject> nearestCrowd =  new List<GameObject>();
        if(crowd == null)
        {
            return null;
        }
        foreach (GameObject obj in crowd)
        {
            if (Vector3.Distance(obj.transform.position, position) <= maxRange)
            {
                nearestCrowd.Add(obj);
            }
        }
        return nearestCrowd;
    }

}
