using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem = null;
    [SerializeField] private Slider slider = null;

    private void OnEnable()
    {
        if (!healthSystem)
            return;

        healthSystem.PlayerHurt += OnPlayerHurt;
    }
    
    private void OnDisable()
    {
        if (!healthSystem)
            return;

        healthSystem.PlayerHurt -= OnPlayerHurt;
    }

    private void OnPlayerHurt(float damage)
    {
        slider.value = healthSystem.Health;
    }
}
