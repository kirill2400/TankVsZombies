using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float MaxHealth => _maxHealth;
    public float Health => _health;
    public float MaxArmor => _maxArmor;
    public float Armor => _armor;
    public bool IsDead => _health <= 0f;

    public event Action<float> PlayerHurt;
    public event Action<HealthSystem> Died;

    [SerializeField] private PlayerCharacteristics characteristics = null;
    private float _maxHealth = 100f;
    private float _health = 100f;
    private float _maxArmor = 1f;
    private float _armor = 1f;

    private void OnEnable()
    {
        _maxHealth = characteristics.maxHealth;
        _health = characteristics.health;
        _maxArmor = characteristics.maxArmor;
        _armor = characteristics.armor;
    }

    public void DoDamage(float damage)
    {
        if (IsDead)
            return;

        if (!(damage > 0f))
            return;
        
        damage = damage * (_maxArmor - _armor);
        if (_health > damage)
        {
            _health -= damage;
            PlayerHurt?.Invoke(damage);
        }
        else
        {
            damage = _health;
            _health = 0f;
            PlayerHurt?.Invoke(damage);
            Died?.Invoke(this);
        }
    }
}
