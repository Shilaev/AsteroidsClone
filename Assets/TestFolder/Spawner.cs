using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private int _size;
    [SerializeField] private bool _isAutoExpand = false;
    [SerializeField] private PoolElement _poolElement;
    private Pool myPool = new Pool();

    private void Start()
    {
        myPool.Initialize(_tag, _size, _isAutoExpand, _poolElement);

    }

    private void Update()
    {
        // if (Mouse.current.leftButton.wasReleasedThisFrame)
        // {
        //     Spawn();
        // }
        //
        // if (Mouse.current.rightButton.wasReleasedThisFrame)
        // {
        //     //
        // }
    }
    public void Spawn()
    {
        // GameObject spawnObject = myPool.GetFreeElement().gameObject;
        //
        // if (spawnObject != null)
        // {
        //     spawnObject.SetActive(true);
        //
        //     var rand = Random.Range(-2, 2);
        //     var rand2 = Random.Range(-2, 2);
        //     spawnObject.transform.position = new Vector3(rand, rand2);
        //
        //     var randC1 = Random.ColorHSV();
        //     spawnObject.GetComponent<SpriteRenderer>().color = randC1;
        // }
    }
}