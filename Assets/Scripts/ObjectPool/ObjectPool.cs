using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectPool
{
    public string Id { get; }
    private List<GameObject> _pooledObjects = new List<GameObject>();
    private Transform _transform;

    public ObjectPool(string id)
    {
        Id = id;
        _transform = new GameObject(id).transform;
    }

    public GameObject GetPooledObject(GameObject prefab)
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
            if (!_pooledObjects[i].activeInHierarchy)
                return _pooledObjects[i];

        GameObject tmp = Object.Instantiate(prefab, _transform);

        _pooledObjects.Add(tmp.gameObject);
        return tmp;
    }
}
