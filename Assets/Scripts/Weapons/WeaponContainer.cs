using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponContainer : MonoBehaviour
{
    [SerializeField] private VisualCrossHair visualCrossHair = null;
    [SerializeField] private PlayerInputBase playerInputBase = null;
    [SerializeField] private List<Weapon> weaponsList = null;
    private Weapon _currentWeapon = null;

    private void OnEnable()
    {
        if (weaponsList.Count > 0)
            _currentWeapon = weaponsList[0];
        
        if (visualCrossHair)
            visualCrossHair.SetCurrentWeapon(_currentWeapon.GetFirePoint());
        
        if (!playerInputBase)
            return;
        
        playerInputBase.StartFire += StartFire;
        playerInputBase.StopFire += StopFire;
        playerInputBase.ChangeWeapon += ChangeWeapon;
    }

    private void OnDisable()
    {
        if (!playerInputBase)
            return;
        
        playerInputBase.StartFire -= StartFire;
        playerInputBase.StopFire -= StopFire;
        playerInputBase.ChangeWeapon -= ChangeWeapon;
    }

    public void StartFire()
    {
        if (_currentWeapon)
            _currentWeapon.StartFire();
    }

    public void StopFire()
    {
        if (_currentWeapon)
            _currentWeapon.StopFire();
    }

    public void ChangeWeapon(bool nextWeapon)
    {
        if (_currentWeapon)
            _currentWeapon.StopFire();
        
        var index = weaponsList.IndexOf(_currentWeapon);
        if (index < 0)
            return;

        if (nextWeapon && ++index >= weaponsList.Count)
            index = 0;
        else if (!nextWeapon && --index < 0)
            index = weaponsList.Count - 1;
        
        _currentWeapon = weaponsList[index];
        
        if (visualCrossHair)
            visualCrossHair.SetCurrentWeapon(_currentWeapon.GetFirePoint());
    }
}
