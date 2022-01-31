using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class MonoObjectPool<T> where T : MonoBehaviour
{
    private List<T> _pool;

    public MonoObjectPool(T prefab, int size)
    {
        Prefab = prefab;
        Container = null;
        CreatePool(size);
    }

    public MonoObjectPool(T prefab, int size, Transform container)
    {
        Prefab = prefab;
        Container = container;
        CreatePool(size);
    }

    public T Prefab { get; }
    public Transform Container { get; }
    public bool AutoExpand { get; set; }

    private bool HasFreeElement(out T freeElement)
    {
        foreach (var poolElement in _pool)
            if (poolElement.gameObject.activeInHierarchy == false)
            {
                poolElement.gameObject.SetActive(true);
                freeElement = poolElement;
                return true;
            }

        freeElement = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out T freeElement)) return freeElement;

        if (AutoExpand) return CreateObject(true);

        throw new Exception($"No free elements in pool of type {typeof(T)}");
    }

    private void CreatePool(int size)
    {
        _pool = new List<T>();

        for (var i = 0; i < size; i++) CreateObject();
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(Prefab, Container);
        createdObject.gameObject.SetActive(isActiveByDefault);

        _pool.Add(createdObject);
        return createdObject;
    }
}