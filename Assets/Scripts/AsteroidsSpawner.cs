using System;
using CameraFeatures;
using ObjectPool;
using UnityEngine;
using UnityEngine.InputSystem;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Keyboard.current.fKey.wasReleasedThisFrame)
        {
            SpawnBigAsteroid();
        }
    }

    public static void SpawnBigAsteroid()
    {
        Pool.GetElementFromPoolWithTag("BigAsteroids");
    }

    public static void SpawnSmallAsteroid()
    {
        // Pool.GetElementFromPoolWithTag("SmallAsteroids");
        Debug.Log("SmallAsteroid");
    }
}