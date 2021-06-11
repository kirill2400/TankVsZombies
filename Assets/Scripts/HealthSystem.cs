using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IHealthSystem
{
    public float Health => health;
    public float Armor => armor;
    public bool IsDead => health <= 0f;

    [SerializeField] private float health = 100f;
    
    [Range(0f, 1f)]
    [SerializeField] private float armor = 1f;

    public void DoDamage(float damage)
    {
        if (damage > 0f)
            health -= damage * armor;

        if (health < 0f)
            health = 0f;
    }
}
