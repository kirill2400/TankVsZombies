using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public bool IsFiring => _fireRoutine != null;
    
    [SerializeField] protected BasicWeaponScriptableObject basicWeaponScriptableObject;

    private Coroutine _fireRoutine;
    private float _nextFireTime;

    public void StartFire()
    {
        _fireRoutine = StartCoroutine(StartShooting());
    }

    public void StopFire()
    {
        if (_fireRoutine != null)
        {
            StopCoroutine(_fireRoutine);
            _fireRoutine = null;
        }
    }

    private IEnumerator StartShooting()
    {
        while (true)
        {
            if (Time.time > _nextFireTime)
            {
                _nextFireTime = Time.time + basicWeaponScriptableObject.FireRate;

                Shoot();
                if (basicWeaponScriptableObject.fireMode == FireMode.Single)
                    yield break;
            }

            yield return null;
        }
    }

    protected abstract void Shoot();

    public abstract Transform GetFirePoint();
}
