using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    protected HealthSystem healthSystem;
    protected Slider healthSlider;

    protected virtual void Start()
    {
        // Get the health system from the parent or by tag (override in derived classes)
        this.healthSystem = GetHealthSystem();

        this.healthSlider = this.GetComponent<Slider>();
        healthSlider.value = healthSystem.GetHealthPercent();

        // Subscribe to health changed event
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }

    // Method to be overridden in derived classes to determine how to get the HealthSystem
    protected virtual HealthSystem GetHealthSystem()
    {
        return this.GetComponentInParent<HealthSystem>();
    }

    // Update health bar
    private void HealthSystem_OnHealthChanged(object sender, EventArgs e)
    {
        // Changing the value of the slider (health bar)
        healthSlider.value = healthSystem.GetHealthPercent() / 100f;
    }
}
