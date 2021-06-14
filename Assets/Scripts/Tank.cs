using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IHealthSystem))]
public class Tank : MonoBehaviour
{
    public Player Owner = null;
    public TankMover TankMover = null;
    public WeaponContainer WeaponContainer = null;
    
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
        WeaponContainer.SetOwner(player);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Enemy>())
            Debug.Log("Enemy hit");
    }
}
