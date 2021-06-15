using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableKilledObjects : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem = null;

    private void OnEnable()
    {
        if (!healthSystem)
            return;

        healthSystem.Died += DisableObject;
    }

    private void OnDisable()
    {
        if (!healthSystem)
            return;

        healthSystem.Died -= DisableObject;
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
