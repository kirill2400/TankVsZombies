using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public static class ObjectPool<T> where T : MonoBehaviour
{
    private static List<GameObject> _pooledObjects = new List<GameObject>();
    private static Transform _transform;

    public static GameObject GetPooledObject(GameObject prefab)
    {
        if (!_transform)
            _transform = new GameObject(typeof(T).FullName).transform;

        for (int i = 0; i < _pooledObjects.Count; i++)
            if (!_pooledObjects[i].activeInHierarchy)
                return _pooledObjects[i];

        GameObject tmp = Object.Instantiate(prefab, _transform);

        _pooledObjects.Add(tmp.gameObject);
        return tmp;
    }
}
