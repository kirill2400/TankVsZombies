using System.Collections.Generic;
using UnityEngine;

public static class ObjectPoolContainer
{
    private static Dictionary<string, ObjectPool> _objectPools = new Dictionary<string, ObjectPool>();

    public static GameObject GetPooledObject(PoolableObject prefab)
    {
        var poolableId = prefab.GetPoolableId();
        
        if (!_objectPools.ContainsKey(poolableId))
            _objectPools.Add(poolableId, new ObjectPool(poolableId));
        
        return _objectPools[poolableId].GetPooledObject(prefab.gameObject);
    }
}
