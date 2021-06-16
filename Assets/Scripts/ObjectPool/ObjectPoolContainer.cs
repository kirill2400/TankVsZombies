using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolContainer : MonoBehaviour
{
    public static ObjectPoolContainer Instance;
    private Dictionary<string, ObjectPool> _objectPools = new Dictionary<string, ObjectPool>();

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public GameObject GetPooledObject(PoolableObject prefab)
    {
        var poolableId = prefab.GetPoolableId();

        if (!_objectPools.ContainsKey(poolableId))
        {
            var pool = new GameObject(poolableId, typeof(ObjectPool));
            pool.transform.SetParent(transform);
            _objectPools.Add(poolableId, pool.GetComponent<ObjectPool>());
        }

        return _objectPools[poolableId].GetPooledObject(prefab.gameObject);
    }
}
