using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiInput : PlayerInputBase
{
    public override event Action<Vector2> Move;
    public override event Action StartFire;
    public override event Action StopFire;
    public override event Action<bool> ChangeWeapon;
    
    [SerializeField] private Transform target = null;
    
    private Vector2 _moveInput;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Update()
    {
        CheckMoveInput();
    }
    
    private void CheckMoveInput()
    {
        Vector3 direction = target.position - _transform.position;
        _moveInput.x = AngleDir(_transform.forward, direction, _transform.up);
        _moveInput.y = 1f;
        
        Move?.Invoke(_moveInput);
    }
    
    public float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);
 
        if (dir > 0.0f)
            return 1.0f;
        if (dir < 0.0f)
            return -1.0f;
        return 0.0f;
    }  
}
