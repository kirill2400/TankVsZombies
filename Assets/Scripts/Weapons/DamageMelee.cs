using UnityEngine;

public class DamageMelee : MonoBehaviour
{
    [SerializeField] private MeleeWeapon meleeWeapon = null;
    [SerializeField] private LayerMask enemyLayer = default;

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.activeInHierarchy)
            return;

        if (!enemyLayer.Contains(other.gameObject.layer))
            return;
        
        var health = other.collider.GetComponent<HealthSystem>();
        if (health)
            health.DoDamage(meleeWeapon.Damage);
    }
}
