using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMelee : MonoBehaviour
{
    [SerializeField] private MeleeWeapon meleeWeapon;

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.activeInHierarchy)
            return;
        
        var health = other.collider.GetComponent<HealthSystem>();
        if (health)
            health.DoDamage(meleeWeapon.Damage);
    }
}
