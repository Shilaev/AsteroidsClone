using System;
using System.Collections.Generic;
using UnityEngine;

// Добавить родительский объект, в который спавнятся остальные для удобства навигации в сцене
public class Pool : MonoBehaviour
{
    private string _tag;
    private int _size;
    private bool _isAutoExpand = false;
    private PoolElement _poolElement;
    private List<PoolElement> _elements = new List<PoolElement>();

    public void Initialize(string tag, int size, bool isAutoExpand, PoolElement poolElement)
    {
        _tag = tag;
        _size = size;
        _isAutoExpand = isAutoExpand;
        _poolElement = poolElement;

        for (int i = 0; i < _size; i++)
        {
            AddElement(_poolElement);
        }
    }

    private void AddElement(PoolElement poolElement)
    {
        PoolElement temp = Instantiate(poolElement);
        temp.gameObject.SetActive(false);
        _elements.Add(temp);
    }

    public PoolElement GetFreeElement()
    {
        foreach (var poolElement in _elements)
        {
            if (poolElement.gameObject.activeInHierarchy == false)
            {
                return poolElement;
            }
        }

        if (_isAutoExpand)
            AddElement(_elements[0]);

        throw new Exception($"No elements in {_tag} pool");
    }

    // {
    // public Pool(string tag, int size, bool isAutoExpand, PoolElement poolElement)
    //     _tag = tag;
    //     _size = size;
    //     _isAutoExpand = isAutoExpand;
    //     _poolElement = poolElement;
    //
    //     Initialize();
    // }
}