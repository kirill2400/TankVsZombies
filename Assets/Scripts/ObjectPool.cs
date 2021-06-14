using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    private Dictionary<Type, List<GameObject>> pooledObjects = new Dictionary<Type, List<GameObject>>();

    private void Awake()
    {
        Instance = this;
    }

    public T GetPooledObject<T>(T prefab) where T : MonoBehaviour
    {
        if (pooledObjects.TryGetValue(typeof(T), out var pooledList))
            for (int i = 0; i < pooledList.Count; i++)
                if (!pooledList[i].activeInHierarchy)
                    return pooledList[i].GetComponent<T>();

        T tmp = Instantiate(prefab, transform);
        
        if (!pooledObjects.ContainsKey(typeof(T)))
            pooledObjects.Add(typeof(T), new List<GameObject>());
        
        pooledObjects[typeof(T)].Add(tmp.gameObject);
        return tmp;
    }
}
