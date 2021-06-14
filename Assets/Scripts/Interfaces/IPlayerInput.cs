using System;
using UnityEngine;

public interface IPlayerInput
{
    public event Action<Vector2> Move;
    public event Action StartFire;
    public event Action StopFire;
    public event Action<bool> ChangeWeapon;

    public void HandleInput();
}
