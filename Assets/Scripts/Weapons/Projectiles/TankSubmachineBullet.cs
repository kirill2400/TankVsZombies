using UnityEngine;

public class TankSubmachineBullet : Projectile
{
    [SerializeField] private LayerMask collideLayerMask;
    
    private void OnTriggerEnter(Collider other)
    {
        if (collideLayerMask.Contains(other.gameObject.layer))
        {
            var health = other.GetComponent<HealthSystem>();
            if (health)
                health.DoDamage(_projectileWeapon.Damage * (ElapsedTime / _projectileWeapon.AliveTime));
        }

        DestroyProjectile();
    }
}
