using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourVoid : MonoBehaviour
{
    void Update()
    {
        MoveTowardsCursor();
    }

    private void MoveTowardsCursor()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        this.transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, 0);
    }
}
