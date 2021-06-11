using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour, ITankMover
{
    public float MoveSpeed = 5f;
    public float RotateSpeed = 5f;
    
    [SerializeField] private Transform tankTransform;
    
    private Vector2 moveInput;

    public void SetMoveInput(Vector2 move)
    {
        moveInput = move;

        if (moveInput.y < 0)
            moveInput.x *= -1;
    }

    public void ApplyMovement()
    {
        tankTransform.Rotate(0f, moveInput.x * RotateSpeed, 0f);
        tankTransform.Translate(tankTransform.forward * (moveInput.y * MoveSpeed), Space.World);
    }
}
