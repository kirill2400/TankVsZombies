using UnityEngine;

public class TankHeadRotator : MonoBehaviour
{
    public float MoveTowerSpeed = 0.005f;
    public float MoveGunSpeed = 0.005f;

    [SerializeField] protected float maxDistance = 25f;
    [SerializeField] protected Transform gunTower;
    [SerializeField] protected Transform gunPivot;

    private Collider _target;
    
    private void Update()
    {
        var colliders = Physics.OverlapSphere(transform.position, maxDistance, LayerMask.GetMask("Enemies"));
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
        var newRotation =
            Quaternion.RotateTowards(gunTower.rotation, Quaternion.LookRotation(dir), Time.fixedDeltaTime * MoveTowerSpeed);
        
        if (Mathf.Abs(gunTower.rotation.eulerAngles.y - newRotation.eulerAngles.y) < .1f)
        {
            dir = _target.bounds.center - gunPivot.position;
            gunPivot.rotation = Quaternion.RotateTowards(gunPivot.rotation, Quaternion.LookRotation(dir),
                Time.fixedDeltaTime * MoveGunSpeed);
            gunTower.rotation = newRotation;
        }
        else
            gunTower.rotation = newRotation;
    }
}
