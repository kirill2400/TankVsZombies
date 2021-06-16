using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected ProjectileScriptableObject _projectileWeapon;
    protected Transform Transform;
    protected float ElapsedTime;

    private Coroutine _destroyRoutine;

    protected virtual void Awake()
    {
        Transform = GetComponent<Transform>();
    }

    protected virtual void OnEnable()
    {
        _destroyRoutine = StartCoroutine(AutoDestroy());
    }

    protected virtual void FixedUpdate()
    {
        Transform.Translate(Transform.forward * (_projectileWeapon.ProjectileSpeed * Time.fixedDeltaTime), Space.World);
    }

    protected virtual IEnumerator AutoDestroy()
    {
        ElapsedTime = _projectileWeapon.AliveTime;
        while (ElapsedTime > 0f)
        {
            yield return null;
            ElapsedTime -= Time.deltaTime;
        }
        
        DestroyProjectile();
    }

    protected virtual void DestroyProjectile()
    {
        gameObject.SetActive(false);
        StopAllCoroutines();
    }
}
