using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponContainer : MonoBehaviour
{
    public Player Owner = null;

    [SerializeField] private Weapon weapon = null;

    public void SetOwner(Player player)
    {
        Owner = player;
        weapon.SetOwner(player);
    }

    public void StartFire()
    {
        weapon.StartFire();
    }

    public void StopFire()
    {
        weapon.StopFire();
    }
}
