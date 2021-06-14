using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireType
{
    Single = 0,
    Multiply
}

public class Weapon : MonoBehaviour
{
    public Player Owner;
    public float Damage => damage;
    public float FireRate => fireRate;

    [SerializeField] protected Projectile projectilePrefab = null;
    [SerializeField] protected Transform spawnProjectilePosition = null;
    [SerializeField] protected Transform gunPivot = null;
    [SerializeField] protected FireType fireType = FireType.Single;
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float projectileSpeed = 1f;

    [Range(0f, 10f)]
    [SerializeField] protected float fireRate = 1f;

    private Coroutine _fireRoutine;
    private float _nextFireTime;
    
    private void FixedUpdate()
    {
        var colliders = Physics.OverlapSphere(transform.position, 50f, LayerMask.GetMask("Enemies"));
        float distance = float.MaxValue;
        Transform toRotate = null;
        foreach (var coll in colliders)
        {
            var tmp = (coll.transform.position - transform.position).magnitude;
            if (tmp < distance)
            {
                distance = tmp;
                toRotate = coll.transform;
            }
        }

        if (!Equals(toRotate, null))
        {
            transform.LookAt(toRotate);
            gunPivot.LookAt(toRotate);
            Debug.DrawLine(transform.position, toRotate.position, Color.red);
        }
    }

    public void StartFire()
    {
        _fireRoutine = StartCoroutine(StartShooting());
    }

    public void StopFire()
    {
        if (_fireRoutine != null)
            StopCoroutine(_fireRoutine);
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
        Projectile projectile = ObjectPool.Instance.GetPooledObject(projectilePrefab);

        Transform projTransform = projectile.transform;
        projTransform.position = spawnProjectilePosition.position;
        projTransform.rotation = spawnProjectilePosition.rotation;
        
        projectile.SetupProjectile(Owner, projectileSpeed, damage, projTransform.forward);
        projectile.gameObject.SetActive(true);
    }

    public void SetOwner(Player player)
    {
        Owner = player;
    }
}
