using System;
using System.Collections.Generic;
using ObjectPool;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PoolSpawner : MonoBehaviour
{
    [SerializeField] private List<Pool_SO> _pools_so = new List<Pool_SO>();
    private List<Pool> _pools = new List<Pool>();

    private void Start()
    {
        foreach (var poolSo in _pools_so)
        {
            var newPool = new Pool();
            newPool.Initialize(poolSo.tag, poolSo.size, poolSo.isAutoExpand, poolSo.prefab);
            _pools.Add(newPool);
        }

        foreach (var pool in _pools)
        {
            Debug.Log(pool.Tag);
        }
    }

    // private void Update()
    // {
    //     if (Mouse.current.leftButton.wasReleasedThisFrame)
    //     {
    //         SpawnPoolObjectWithTag("q");
    //     }
    //
    // if (Mouse.current.rightButton.wasReleasedThisFrame)
    // {
    //     //
    // }
    // }

    public void SpawnPoolObjectWithTag(string tag)
    {
        foreach (var pool in _pools)
        {
            if (pool.Tag == tag)
            {
                GameObject spawnObject = pool.GetFreeElement().gameObject;

                if (spawnObject != null)
                {
                    spawnObject.SetActive(true);

                    var rand = Random.Range(-2, 2);
                    var rand2 = Random.Range(-2, 2);
                    spawnObject.transform.position = new Vector3(rand, rand2);

                    var randC1 = Random.ColorHSV();
                    spawnObject.GetComponent<SpriteRenderer>().color = randC1;
                }
            }
        }
    }
}