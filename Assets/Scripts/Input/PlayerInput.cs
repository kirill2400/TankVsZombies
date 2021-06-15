using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : PlayerInputBase
{
    public override event Action<Vector2> Move;
    public override event Action StartFire;
    public override event Action StopFire;
    public override event Action<bool> ChangeWeapon;

    private Vector2 _moveInput;
    private bool _isFiring;
    private bool _isChangeWeaponButtonDown;

    public void Update()
    {
        CheckMoveInput();
        CheckFireInput();
        CheckChangeWeaponInput();
    }

    private void CheckMoveInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        _moveInput.x = horizontal;
        _moveInput.y = vertical;
        
        Move?.Invoke(_moveInput);
    }

    private void CheckFireInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartFire?.Invoke();
            _isFiring = true;
        }

        if (_isFiring && Input.GetButtonUp("Fire1"))
        {
            StopFire?.Invoke();
            _isFiring = false;
        }
    }

    private void CheckChangeWeaponInput()
    {
        float changeWeaponInput = Input.GetAxisRaw("Change Weapon");
        
        // Возможно стоит делать проверку такого вида: Mathf.Abs(changeWeaponInput - 1f) < float.Epsilon
        if (Mathf.Abs(changeWeaponInput) == 1f)
        {
            if (_isChangeWeaponButtonDown == false)
                ChangeWeapon?.Invoke(changeWeaponInput == 1f);
            
            _isChangeWeaponButtonDown = true;
        }
        else
            _isChangeWeaponButtonDown = false;
    }
}
