using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "ScriptableObjects/Weapon/Projectile/Projectile")]
public class ProjectileScriptableObject : ScriptableObject
{
    public float AliveTime;
    public float Damage;
    public float ProjectileSpeed;
}