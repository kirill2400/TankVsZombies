using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePressure : MonoBehaviour
{
    [SerializeField] private MeleeWeapon meleeWeapon;
    
    private void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<HealthSystem>();
        if (health)
            health.DoDamage(meleeWeapon.Damage);
    }
}
