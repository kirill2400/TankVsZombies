using UnityEngine;

public class DamagePressure : MonoBehaviour
{
    [SerializeField] private MeleeWeapon meleeWeapon;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.activeInHierarchy)
            return;
        
        var health = other.GetComponent<HealthSystem>();
        if (health)
            health.DoDamage(meleeWeapon.Damage);
    }
}
