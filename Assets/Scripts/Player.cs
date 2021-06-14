using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IPlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private Tank tank = null;
    private IPlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<IPlayerInput>();
    }

    private void Start()
    {
        tank.SetOwner(this);
        
        _playerInput.Move += PlayerInputOnMove;
        _playerInput.StartFire += PlayerInputOnStartFire;
        _playerInput.StopFire += PlayerInputOnStopFire;
        _playerInput.ChangeWeapon += PlayerInputOnChangeWeapon;
    }

    private void OnDestroy()
    {
        _playerInput.Move -= PlayerInputOnMove;
        _playerInput.StartFire -= PlayerInputOnStartFire;
        _playerInput.StopFire -= PlayerInputOnStopFire;
        _playerInput.ChangeWeapon -= PlayerInputOnChangeWeapon;
    }

    private void Update()
    {
        _playerInput.HandleInput();
    }

    private void PlayerInputOnMove(Vector2 move)
    {
        tank.TankMover.SetMoveInput(move);
    }
    
    private void PlayerInputOnStartFire()
    {
        tank.WeaponContainer.StartFire();
    }
    
    private void PlayerInputOnStopFire()
    {
        tank.WeaponContainer.StopFire();
    }
    
    private void PlayerInputOnChangeWeapon(bool obj)
    {
        
    }
}
