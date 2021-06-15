using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCannon : ProjectileWeapon
{
    protected override GameObject GetProjectileFromPool()
    {
        return ObjectPool<TankExplosiveCharges>.GetPooledObject(basicWeaponScriptableObject.projectilePrefab);
    }

    protected override void Shoot()
    {
        base.Shoot();
        // Визуальное и звуковое сопровождение выстрела
    }
}
