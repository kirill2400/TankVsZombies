using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider = null;

    private void OnEnable()
    {
        if (!LocalPlayer.HealthSystem)
            return;

        LocalPlayer.HealthSystem.PlayerHurt += OnPlayerHurt;
    }
    
    private void OnDisable()
    {
        if (!LocalPlayer.HealthSystem)
            return;

        LocalPlayer.HealthSystem.PlayerHurt -= OnPlayerHurt;
    }

    private void OnPlayerHurt(float damage)
    {
        slider.value = LocalPlayer.HealthSystem.Health;
    }
}
