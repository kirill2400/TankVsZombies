using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Vector3 offset = Vector3.zero;
    [SerializeField] private float cameraSpeed = 0.1f;
    [SerializeField] private Transform target = null;
    private Transform _transform;
    
    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Vector3 position = _transform.position;
        Vector3 targetPosition = target.position;
        
        position.x = Mathf.Lerp(position.x, targetPosition.x + offset.x, cameraSpeed * Time.fixedDeltaTime);
        position.y = Mathf.Lerp(position.y, targetPosition.y + offset.y, cameraSpeed * Time.fixedDeltaTime);
        position.z = Mathf.Lerp(position.z, targetPosition.z + offset.z, cameraSpeed * Time.fixedDeltaTime);

        _transform.position = position;
    }
}
