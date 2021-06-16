using UnityEngine;

public abstract class ProjectileWeapon : Weapon
{
    [SerializeField] private Transform spawnProjectilePosition;
    
    protected override void Shoot()
    {
        GameObject projectile = ObjectPoolContainer.GetPooledObject(basicWeaponScriptableObject.projectilePrefab);

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
