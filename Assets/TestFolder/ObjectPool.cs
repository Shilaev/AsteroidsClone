using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool _instance;

    private List<GameObject> _pooledObjects = new List<GameObject>();
    private int _size = 20;

    [SerializeField] private GameObject _prefab;

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(_instance);
    }

    private void Start()
    {
        for (int i = 0; i < _size; i++)
        {
            GameObject obj = Instantiate(_prefab);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        return null;
    }

    public GameObject GetActivePooledObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        return null;
    }
}