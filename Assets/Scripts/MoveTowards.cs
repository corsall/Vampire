using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MoveTowards : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent navMesh;

    void Start()
    {   
        player = GameObject.FindWithTag("Player");
        navMesh = this.GetComponent<NavMeshAgent>();
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;
    }

    private void Update()
    {
        navMesh.SetDestination(player.transform.position);
    }
}
