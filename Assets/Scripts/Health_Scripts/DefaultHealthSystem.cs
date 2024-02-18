using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultHealthSystem : HealthSystem
{
    [SerializeField]
    public override float Health { get; protected set; } = 100f;
    [SerializeField]
    public override float HealthMax { get; protected set; } = 100f;
}
