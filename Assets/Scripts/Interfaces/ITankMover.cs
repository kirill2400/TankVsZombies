using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITankMover
{
    public void SetMoveInput(Vector2 move);
    public void ApplyMovement();
}
