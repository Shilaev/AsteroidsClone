using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PoolsManager : MonoBehaviour
{
    // pool tag, pool elements
    [SerializeField] private Dictionary<string, List<PoolElement>> _poolsDictionary;

    private void Start()
    {
        //
    }
}