using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;
    
    [SerializeField] private Transform thisTransform;
    [SerializeField] private PlayerInputBase playerInputBase;
    [SerializeField] private PlayerCharacteristics characteristics = null;

    private Vector2 _moveInput;

    private void Awake()
    {
        if (characteristics)
        {
            moveSpeed = characteristics.movementSpeed;
            rotateSpeed = characteristics.rotateSpeed;
        }
    }

    private void OnEnable()
    {
        if (!playerInputBase)
            return;
        
        playerInputBase.Move += SetMoveInput;
    }

    private void OnDisable()
    {
        if (!playerInputBase)
            return;
        
        playerInputBase.Move -= SetMoveInput;
    }

    public void SetMoveInput(Vector2 move)
    {
        _moveInput = move;

        if (_moveInput.y < 0)
            _moveInput.x *= -1;
    }

    public void FixedUpdate()
    {
        if (!thisTransform)
            return;
        
        thisTransform.Rotate(0f, _moveInput.x * rotateSpeed * Time.fixedDeltaTime, 0f, Space.World);
        thisTransform.Translate(thisTransform.forward * (_moveInput.y * moveSpeed * Time.fixedDeltaTime), Space.World);
    }
}
