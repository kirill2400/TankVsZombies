using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCrossHair : MonoBehaviour
{
    [HideInInspector] public HealthSystem currentTarget;
    
    [SerializeField] private float maxDistance = 25f;
    [SerializeField] private GameObject marker = null;
    [SerializeField] private Material redMaterial = null;
    [SerializeField] private Material greenMaterial = null;

    private Transform _cameraTransform;
    private MeshRenderer _markerMesh;
    private Transform _spawnProjectilePosition = null;

    public void SetCurrentWeapon(Transform sourceWeaponPoint)
    {
        _spawnProjectilePosition = sourceWeaponPoint;
    }

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
        if (marker)
            _markerMesh = marker.GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        if (marker)
            marker.SetActive(true);
    }

    private void OnDisable()
    {
        if (marker)
            marker.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(new Ray(_spawnProjectilePosition.position, _spawnProjectilePosition.forward), out var hit, maxDistance))
        {
            currentTarget = hit.collider.GetComponent<HealthSystem>();
            
            if (!marker)
                return;
            
            marker.transform.position = hit.point;
            _markerMesh.material = redMaterial;
        }
        else
        {
            currentTarget = null;
            
            if (!marker)
                return;
            
            marker.transform.position =
                _spawnProjectilePosition.position + _spawnProjectilePosition.forward * maxDistance;
            _markerMesh.material = greenMaterial;
        }
    }
}
