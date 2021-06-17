using UnityEngine;

public class TankHeadRotator : MonoBehaviour
{
    public float MoveTowerSpeed = 0.005f;
    public float MoveGunSpeed = 0.005f;

    [SerializeField] private LayerMask detectLayerMask;
    [SerializeField] private float maxDistance = 25f;
    [SerializeField] private Transform gunTower;
    [SerializeField] private Transform gunPivot;

    private Collider _target;
    
    private void Update()
    {
        var colliders = Physics.OverlapSphere(transform.position, maxDistance, detectLayerMask);
        float distance = float.MaxValue;
        foreach (var coll in colliders)
        {
            var tmp = (coll.transform.position - gunTower.position).sqrMagnitude;
            if (tmp < distance)
            {
                distance = tmp;
                _target = coll;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Equals(_target, null) || !_target.gameObject.activeInHierarchy)
            return;
        
        Vector3 dir = _target.bounds.center - gunTower.position;
        dir.y = 0f;
        gunTower.rotation = Quaternion.RotateTowards(gunTower.rotation, Quaternion.LookRotation(dir),
            Time.fixedDeltaTime * MoveTowerSpeed);
        
        dir = _target.bounds.center - gunPivot.position;
        var lookRotation = Quaternion.LookRotation(dir);
        var lookRotationEuler = lookRotation.eulerAngles;
        lookRotationEuler.y = 0f;
        lookRotationEuler.z = 0f;
        lookRotation.eulerAngles = lookRotationEuler;
        
        gunPivot.localRotation = Quaternion.RotateTowards(gunPivot.localRotation, lookRotation,
            Time.fixedDeltaTime * MoveGunSpeed);
    }
}
