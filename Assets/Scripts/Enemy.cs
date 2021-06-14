using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private float moveSpeed = 5f;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _transform.LookAt(target);
        _transform.Translate(_transform.forward * moveSpeed, Space.World);
    }
}
