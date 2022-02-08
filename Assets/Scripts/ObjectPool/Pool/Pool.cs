using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    [AddComponentMenu("Object Pool/Pool")]
    public class Pool : MonoBehaviour
    {
        private static readonly List<Pool> _pools = new List<Pool>();
        [SerializeField] private List<Pool_SO> _pools_so = new List<Pool_SO>();

        private List<PoolElement> _elements;
        private bool _isAutoExpand;
        private PoolElement _poolElement;
        private int _size;
        private string _tag;

        private void Start()
        {
            Initialise();
        }

        private void Initialise()
        {
            foreach (var poolSo in _pools_so)
            {
                var newPool = gameObject.AddComponent<Pool>();
                newPool.AddPool(poolSo.tag, poolSo.size, poolSo.isAutoExpand, poolSo.prefab);
                _pools.Add(newPool);
            }
        }

        private void AddPool(string tag, int size, bool isAutoExpand, PoolElement poolElement)
        {
            _tag = tag;
            _size = size;
            _isAutoExpand = isAutoExpand;
            _poolElement = poolElement;
            _elements = new List<PoolElement>();

            foreach (var poolSo in _pools_so)
            {
                var newPool = gameObject.AddComponent<Pool>();
                newPool.AddPool(poolSo.tag, poolSo.size, poolSo.isAutoExpand, poolSo.prefab);
                _pools.Add(newPool);
            }

            for (var i = 0; i < _size; i++) AddElement(_poolElement);
        }

        private void AddElement(PoolElement poolElement)
        {
            var temp = Instantiate(poolElement);
            temp.gameObject.SetActive(false);
            _elements.Add(temp);
        }

        public static GameObject SpawnPoolObjectWithTag(string tag)
        {
            foreach (var pool in _pools)
                if (pool._tag == tag)
                {
                    var spawnObject = pool.GetFreeElement().gameObject;

                    if (spawnObject != null)
                    {
                        spawnObject.SetActive(true);
                        return spawnObject;
                    }
                }

            throw new Exception($"pool with tag '{tag}' is empty.");
        }

        public PoolElement GetFreeElement()
        {
            foreach (var poolElement in _elements)
                if (poolElement.gameObject.activeInHierarchy == false)
                    return poolElement;

            if (_isAutoExpand)
                AddElement(_elements[0]);

            throw new Exception($"No elements in {_tag} pool");
        }
    }
}