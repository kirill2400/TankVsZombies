using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public Player Owner = null;
    [SerializeField] protected float AliveTime = 5f;
    protected float BulletSpeed;
    protected float Damage;
    protected Transform Transform;
    protected Vector3 Direction;

    public virtual void SetupProjectile(Player player, float bulletSpeed, float damage, Vector3 direction)
    {
        Owner = player;
        BulletSpeed = bulletSpeed;
        Damage = damage;
        Direction = direction;
    }

    protected virtual void Awake()
    {
        Transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        StartCoroutine(AutoDestroy());
    }

    protected abstract void FixedUpdate();

    protected virtual IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(AliveTime);
        gameObject.SetActive(false);
    }
}
