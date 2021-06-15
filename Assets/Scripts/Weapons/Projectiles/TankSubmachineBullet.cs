using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSubmachineBullet : Projectile
{
    private void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<HealthSystem>();
        if (health)
            health.DoDamage(_projectileWeapon.Damage * (ElapsedTime / _projectileWeapon.AliveTime));

        DestroyProjectile();
    }
}
