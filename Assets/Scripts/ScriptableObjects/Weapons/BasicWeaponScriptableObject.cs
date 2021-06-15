using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireMode
{
    Single = 0,
    Multiply
}

[CreateAssetMenu(fileName = "BasicWeapon", menuName = "ScriptableObjects/Weapon/BasicWeapon")]
public class BasicWeaponScriptableObject : ScriptableObject
{
    public float FireRate;
    public FireMode fireMode;
    public GameObject projectilePrefab;
}
