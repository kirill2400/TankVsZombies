using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] private Transform toRotate = null;

    private Transform _cameraTransform;
    private HealthSystem _target;

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
        _target = GetComponent<HealthSystem>();
    }

    private void Update()
    {
        slider.maxValue = _target.MaxHealth;
        slider.value = _target.Health;
        
        var cameraNormal = Vector3.Cross(_cameraTransform.up, _cameraTransform.right);
        toRotate.rotation = Quaternion.LookRotation(cameraNormal);
    }
}
