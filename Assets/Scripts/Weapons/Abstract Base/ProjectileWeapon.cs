using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileWeapon : Weapon
{
    [SerializeField] private Transform spawnProjectilePosition;

    protected virtual GameObject GetProjectileFromPool()
    {
        return ObjectPool<Projectile>.GetPooledObject(basicWeaponScriptableObject.projectilePrefab);
    }
    
    protected override void Shoot()
    {
        GameObject projectile = GetProjectileFromPool();

        Transform projTransform = projectile.transform;
        projTransform.position = spawnProjectilePosition.position;
        projTransform.rotation = spawnProjectilePosition.rotation;

        projectile.gameObject.SetActive(true);
    }

    public override Transform GetFirePoint()
    {
        return spawnProjectilePosition;
    }
}
