using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealthBar : UIHealthBar
{
    protected override void Start()
    {
        base.Start();
    }

    protected override HealthSystem GetHealthSystem()
    {
        return GameObject.FindWithTag("Player").GetComponent<HealthSystem>();
    }
}
