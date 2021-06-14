using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    public event Action<Vector2> Move;
    public event Action StartFire;
    public event Action StopFire;
    public event Action<bool> ChangeWeapon;

    private Vector2 _moveInput;
    private bool _isFiring;

    public void HandleInput()
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
        float changeWeaponInput = Input.GetAxis("Change Weapon");
        
        // Возможно стоит делать проверку такого вида: Mathf.Abs(changeWeaponInput - 1f) < float.Epsilon
        if (Mathf.Abs(changeWeaponInput) == 1f)
            ChangeWeapon?.Invoke(changeWeaponInput == 1f);
    }
}
