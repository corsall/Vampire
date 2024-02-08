using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultHealthSystem : HealthSystem
{
    public override float Health { get; protected set; } = 100f;
    public override float HealthMax { get; protected set; } = 100f;
}
