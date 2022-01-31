using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;


public class PoolExample : MonoBehaviour
{

    [SerializeField] private Qube _prefab;
    [SerializeField] [Range(0, 100)] private int _size;
    [SerializeField] private bool _autoExpand;
    private MonoObjectPool<Qube> _pool;

    private void Start()
    {
        _pool = new MonoObjectPool<Qube>(_prefab, _size, transform) {AutoExpand = _autoExpand};
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            CreateCube();
        }
    }

    private void CreateCube()
    {
        var randomX = Random.Range(-5f, 5f);
        var randomY = Random.Range(-5f, 5f);
        var randomPos = new Vector2(randomX, randomY);
        
        var cube = _pool.GetFreeElement();
        cube.transform.position = randomPos;
    }
}
