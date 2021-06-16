using System;
using UnityEngine;

public class AiInput : PlayerInputBase
{
    public override event Action<Vector2> Move;
    public override event Action StartFire;
    public override event Action StopFire;
    public override event Action<bool> ChangeWeapon;
    
    private Transform _target = null;
    private Vector2 _moveInput;
    private Transform _transform;
    private float _elapsedTime;

    private void Awake()
    {
        _transform = transform;
        _target = LocalPlayer.Transform;
    }

    public void Update()
    {
        CheckMoveInput();
    }
    
    private void CheckMoveInput()
    {
        Vector3 direction = _target.position - _transform.position;
        _moveInput.x = AngleDir(_transform.forward, direction, _transform.up);
        _moveInput.y = 1f;

        if (_elapsedTime > 0f)
        {
            _moveInput *= -1;
            _elapsedTime -= Time.deltaTime;
        }
        else if (Physics.Raycast(_transform.position, _transform.forward, 2f, LayerMask.GetMask("Default")))
            _elapsedTime = .5f;
        
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
