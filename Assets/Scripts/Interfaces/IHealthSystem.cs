using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthSystem
{
    public float Health { get; }
    public float Armor { get; }
    public bool IsDead { get; }

    public void DoDamage(float damage);
}
