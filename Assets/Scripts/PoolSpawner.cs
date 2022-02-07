using System.Collections.Generic;
using ObjectPool;
using UnityEngine;

public class PoolSpawner : MonoBehaviour
{
    [SerializeField] private List<Pool_SO> _pools_so = new List<Pool_SO>();
    private readonly List<Pool> _pools = new List<Pool>();

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

    public void SpawnPoolObjectWithTag(string tag)
    {
        foreach (var pool in _pools)
            if (pool.Tag == tag)
            {
                var spawnObject = pool.GetFreeElement().gameObject;

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