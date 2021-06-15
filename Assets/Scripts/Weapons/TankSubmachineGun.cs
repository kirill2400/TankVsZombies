using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSubmachineGun : ProjectileWeapon
{
    protected override GameObject GetProjectileFromPool()
    {
        return ObjectPool<TankSubmachineBullet>.GetPooledObject(basicWeaponScriptableObject.projectilePrefab);
    }

    protected override void Shoot()
    {
        base.Shoot();
        // Визуальное и звуковое сопровождение выстрела
    }
}
