using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : MonoBehaviour
{
    public static HealthSystem HealthSystem;
    public static Transform Transform;

    [SerializeField] private HealthSystem healthSystem = null;

    private void Awake()
    {
        Transform = transform;
        HealthSystem = healthSystem;
    }
}
