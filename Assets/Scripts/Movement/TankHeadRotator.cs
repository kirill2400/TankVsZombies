using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHeadRotator : MonoBehaviour
{
    public float MoveTowerSpeed = 0.005f;
    public float MoveGunSpeed = 0.005f;
    
    [SerializeField] protected Transform gunTower;
    [SerializeField] protected Transform gunPivot;

    private Transform _target;
    
    private void Update()
    {
        var colliders = Physics.OverlapSphere(transform.position, 50f, LayerMask.GetMask("Enemies"));
        float distance = float.MaxValue;
        foreach (var coll in colliders)
        {
            var tmp = (coll.transform.position - gunTower.position).sqrMagnitude;
            if (tmp < distance)
            {
                distance = tmp;
                _target = coll.transform;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Equals(_target, null) || !_target.gameObject.activeInHierarchy)
            return;
        
        Vector3 dir = _target.position - gunTower.position;
        dir.y = 0f;
        var newRotation =
            Quaternion.RotateTowards(gunTower.rotation, Quaternion.LookRotation(dir), Time.fixedDeltaTime * MoveTowerSpeed);
        
        if (Mathf.Abs(gunTower.rotation.eulerAngles.y - newRotation.eulerAngles.y) < .1f)
        {
            dir = _target.position - gunPivot.position;
            gunPivot.rotation = Quaternion.RotateTowards(gunPivot.rotation, Quaternion.LookRotation(dir),
                Time.fixedDeltaTime * MoveGunSpeed);
            gunTower.rotation = newRotation;
        }
        else
            gunTower.rotation = newRotation;
    }
}
