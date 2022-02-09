using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    [AddComponentMenu("Object Pool/Pool")]
    public class Pool : MonoBehaviour
    {
        #region List_of_pools_fields
        [SerializeField] private List<Pool_SO> _pools_so = new List<Pool_SO>();
        private static readonly List<Pool> _pools = new List<Pool>();
        #endregion

        #region Single_pool_fields
        private string _tag;
        private int _size;
        private bool _isAutoExpand;
        private PoolElement _poolElement;
        private List<PoolElement> _poolElements;
        #endregion

        #region PrivateMethods
        private void Start()
        {
            GameManager.instance.OnGameSetup.AddListener(Initialise);
        }

        /// <summary>
        /// Create and prepare all pools,
        /// using scriptable object pool templates
        /// </summary>
        private void Initialise()
        {
            foreach (var poolSo in _pools_so)
            {
                var newPool = gameObject.AddComponent<Pool>();
                newPool.AddPool(poolSo.tag, poolSo.size, poolSo.isAutoExpand, poolSo.prefab);
                _pools.Add(newPool);
            }
        }

        /// <summary>
        /// Add new pool in list of pools
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="size"></param>
        /// <param name="isAutoExpand"></param>
        /// <param name="poolElement"></param>
        private void AddPool(string tag, int size, bool isAutoExpand, PoolElement poolElement)
        {
            _tag = tag;
            _size = size;
            _isAutoExpand = isAutoExpand;
            _poolElement = poolElement;
            _poolElements = new List<PoolElement>();

            foreach (var poolSo in _pools_so)
            {
                var newPool = gameObject.AddComponent<Pool>();
                newPool.AddPool(poolSo.tag, poolSo.size, poolSo.isAutoExpand, poolSo.prefab);
                _pools.Add(newPool);
            }

            for (var i = 0; i < _size; i++) AddElement(_poolElement);
        }

        /// <summary>
        /// Add element in pool
        /// </summary>
        /// <param name="poolElement"></param>
        private void AddElement(PoolElement poolElement)
        {
            var element = Instantiate(poolElement);
            element.gameObject.SetActive(false);
            _poolElements.Add(element);
        }

        private PoolElement GetFreeElement()
        {
            foreach (var poolElement in _poolElements)
                if (poolElement.gameObject.activeInHierarchy == false)
                    return poolElement;

            if (_isAutoExpand)
                AddElement(_poolElements[0]);

            throw new Exception($"No elements in {_tag} pool");
        }
        #endregion

        #region PublicMethods
        public static GameObject GetElementFromPoolWithTag(string tag)
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
        #endregion
    }
}