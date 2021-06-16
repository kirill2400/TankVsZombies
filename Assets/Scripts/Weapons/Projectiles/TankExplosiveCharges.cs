using UnityEngine;

public class TankExplosiveCharges : Projectile
{
    [SerializeField] private LayerMask collideLayerMask;
    private TankExplosiveChargeScriptableObject _tankExplosiveCharge;

    protected override void Awake()
    {
        base.Awake();

        if (_projectileWeapon is TankExplosiveChargeScriptableObject result)
            _tankExplosiveCharge = result;
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyProjectile();
    }

    protected override void DestroyProjectile()
    {
        base.DestroyProjectile();
        
        var colliders = Physics.OverlapSphere(Transform.position, _tankExplosiveCharge.ExplosiveRadius,
            collideLayerMask, QueryTriggerInteraction.Ignore);

        foreach (var oneCollider in colliders)
        {
            var health = oneCollider.GetComponent<HealthSystem>();
            if (!health)
                continue;
            
            var distance = (Transform.position - oneCollider.transform.position).sqrMagnitude;
            health.DoDamage(
                (1f - distance / (_tankExplosiveCharge.ExplosiveRadius * _tankExplosiveCharge.ExplosiveRadius)) *
                _tankExplosiveCharge.Damage);
        }
    }
}
