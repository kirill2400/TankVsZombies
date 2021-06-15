using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private VisualCrossHair visualCrossHair = null;
    [SerializeField] private Slider slider = null;
    
    private void Update()
    {
        slider.gameObject.SetActive(visualCrossHair.currentTarget);
        if (!visualCrossHair.currentTarget)
            return;

        slider.maxValue = visualCrossHair.currentTarget.MaxHealth;
        slider.value = visualCrossHair.currentTarget.Health;
    }
}
