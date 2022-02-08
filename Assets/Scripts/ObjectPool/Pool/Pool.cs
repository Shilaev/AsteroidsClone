﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class Pool : MonoBehaviour
    {
        private string _tag;
        private int _size;
        private bool _isAutoExpand;
        private PoolElement _poolElement;
        private List<PoolElement> _elements;

        public string Tag => _tag;

        public void Initialize(string tag, int size, bool isAutoExpand, PoolElement poolElement)
        {
            _tag = tag;
            _size = size;
            _isAutoExpand = isAutoExpand;
            _poolElement = poolElement;
            _elements = new List<PoolElement>();

            for (var i = 0; i < _size; i++) AddElement(_poolElement);
        }
        
        private void AddElement(PoolElement poolElement)
        {
            var temp = Instantiate(poolElement);
            temp.gameObject.SetActive(false);
            _elements.Add(temp);
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