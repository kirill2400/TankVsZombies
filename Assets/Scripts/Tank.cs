using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IHealthSystem))]
public class Tank : MonoBehaviour
{
    public Player Owner = null;
    public TankMover TankMover = null;
    
    private IHealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponent<IHealthSystem>();
    }

    private void FixedUpdate()
    {
        TankMover.ApplyMovement();
    }

    public void SetOwner(Player player)
    {
        Owner = player;
    }
}
