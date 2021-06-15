using System;
using UnityEngine;

public abstract class PlayerInputBase : MonoBehaviour
{
    public abstract event Action<Vector2> Move;
    public abstract event Action StartFire;
    public abstract event Action StopFire;
    public abstract event Action<bool> ChangeWeapon;
}
