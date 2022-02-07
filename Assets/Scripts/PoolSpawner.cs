using System;
using System.Collections.Generic;
using ObjectPool;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoolSpawner : MonoBehaviour
{
    [SerializeField] private List<Pool_SO> _pools_so = new List<Pool_SO>();
    private readonly List<Pool> _pools = new List<Pool>();

    public static PoolSpawner instance;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(instance);
    }

    private void Start()
    {
        foreach (var poolSo in _pools_so)
        {
            var newPool = new Pool();
            newPool.Initialize(poolSo.tag, poolSo.size, poolSo.isAutoExpand, poolSo.prefab);
            _pools.Add(newPool);
        }

        foreach (var pool in _pools) Debug.Log(pool.Tag);
    }

    public GameObject SpawnPoolObjectWithTag(string tag)
    {
        foreach (var pool in _pools)
        {
            if (pool.Tag == tag)
            {
                var spawnObject = pool.GetFreeElement().gameObject;

                if (spawnObject != null)
                {
                    spawnObject.SetActive(true);

                    // var rand = Random.Range(-2, 2);
                    // var rand2 = Random.Range(-2, 2);
                    // spawnObject.transform.position = new Vector3(rand, rand2);
                    //
                    // var randC1 = Random.ColorHSV();
                    // spawnObject.GetComponent<SpriteRenderer>().color = randC1;
                    return spawnObject;
                }
            }
        }

        throw new Exception("Zero objects");
    }
}