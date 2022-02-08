using System;
using System.Collections.Generic;
using ObjectPool;
using UnityEngine;

public class PoolSpawner : MonoBehaviour
{
    [SerializeField] private List<Pool_SO> _pools_so = new List<Pool_SO>();
    private static List<Pool> _pools = new List<Pool>();

    private void Start()
    {
        foreach (var poolSo in _pools_so)
        {
            var newPool = new Pool();
            newPool.Initialize(poolSo.tag, poolSo.size, poolSo.isAutoExpand, poolSo.prefab);
            _pools.Add(newPool);
        }
    }

    public static GameObject SpawnPoolObjectWithTag(string tag)
    {
        foreach (var pool in _pools)
        {
            if (pool.Tag == tag)
            {
                var spawnObject = pool.GetFreeElement().gameObject;

                if (spawnObject != null)
                {
                    spawnObject.SetActive(true);
                    return spawnObject;
                }
            }
        }

        throw new Exception($"pool with tag '{tag}' is empty.");
    }
}