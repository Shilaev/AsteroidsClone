using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PoolObject : MonoBehaviour
{
    public void ReturnToPool() => gameObject.SetActive(false);
}