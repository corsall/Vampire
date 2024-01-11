using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BigSwordCD
{
    [SerializeField] private float cooldownTime;
    private float nextAttackTime;

    public bool isCoolingDown => Time.time < nextAttackTime;
    public void StartCooldown() => nextAttackTime = Time.time + cooldownTime;

    


}

