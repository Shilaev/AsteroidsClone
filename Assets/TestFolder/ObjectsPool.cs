using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    private List<PoolObject> _pool;
    private Transform _parent;

    public void Initialize(int count, PoolObject template, Transform parent)
    {
        _pool = new List<PoolObject>();
        _parent = parent;

        for (int i = 0; i < count; i++)
            AddObject(template.gameObject, parent);
    }

    private void AddObject(GameObject template, Transform parent)
    {
        GameObject temp = GameObject.Instantiate(template);
        temp.name = template.name;
        temp.transform.SetParent(parent);
        temp.SetActive(false);

        _pool.Add(temp.GetComponent<PoolObject>());
    }

    public PoolObject GetObject()
    {
        foreach (PoolObject poolObject in _pool)
            if (poolObject.gameObject.activeInHierarchy == false)
                return poolObject;

        AddObject(_pool[0].gameObject, _parent);
        return _pool[_pool.Count - 1];
    }
}