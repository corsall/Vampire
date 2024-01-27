using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;
    private Slider healthSlider;

    void Start()
    {
        //Get player 's health system
        this.healthSystem = GameObject.FindWithTag("Player").GetComponent<HealthSystem>();

        this.healthSlider = this.GetComponent<Slider>();
        healthSlider.value = healthSystem.GetHealthPercent();

        //Subscribe to health changed event
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }

    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        Debug.Log(healthSystem.GetHealthPercent());
        //Update health bar

        //Changing the value of the slider(health bar)
        healthSlider.value = healthSystem.GetHealthPercent() / 100f;
    }
}
