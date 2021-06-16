using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> _pooledObjects = new List<GameObject>();
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public GameObject GetPooledObject(GameObject prefab)
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
            if (!_pooledObjects[i].activeInHierarchy)
                return _pooledObjects[i];

        GameObject tmp = Instantiate(prefab, _transform);

        _pooledObjects.Add(tmp.gameObject);
        return tmp;
    }
}
