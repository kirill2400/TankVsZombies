using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireType
{
    Single = 0,
    Multiply
}

public abstract class Weapon : MonoBehaviour
{
    public Player Owner;
    public float Damage => damage;
    public float FireRate => fireRate;

    [SerializeField] protected Projectile projectilePrefab = null;
    [SerializeField] protected Transform spawnProjectilePosition = null;
    [SerializeField] protected FireType fireType = FireType.Single;
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float projectileSpeed = 1f;

    [Range(0f, 10f)]
    [SerializeField] protected float fireRate = 1f;

    private float _nextFireTime;

    public void StartFire()
    {
        StartCoroutine(StartShooting());
    }

    public void StopFire()
    {
        StopCoroutine(StartShooting());
    }

    private IEnumerator StartShooting()
    {
        while (true)
        {
            if (fireType == FireType.Single)
            {
                Shoot();
                yield break;
            }
            else if (Time.time > _nextFireTime)
            {
                _nextFireTime = Time.time + fireRate;
                Shoot();
            }
            yield return null;
        }
    }

    public void Shoot()
    {
        Projectile projectile = Instantiate(projectilePrefab, spawnProjectilePosition.position, transform.rotation);
        projectile.SetupProjectile(Owner, projectileSpeed, damage, projectile.transform.forward);
    }
}
