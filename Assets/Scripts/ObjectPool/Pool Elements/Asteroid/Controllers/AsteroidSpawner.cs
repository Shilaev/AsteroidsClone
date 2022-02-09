using System;
using System.Runtime.InteropServices.ComTypes;
using CameraFeatures;
using ObjectPool;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

[AddComponentMenu("Controllers/AsteroidSpawner")]
public class AsteroidSpawner : MonoBehaviour
{
    private void Update()
    {
        // if (Keyboard.current.fKey.wasReleasedThisFrame) SpawnBigAsteroid();
    }

    private void Start()
    {

        GameManager.instance.OnGameStart.AddListener(delegate
        {
            for (int i = 0; i < 10; i++)
            {
                SpawnBigAsteroid();
            }
        });
    }

    public static void SpawnBigAsteroid()
    {
        var newBigAsteroid = Pool.GetElementFromPoolWithTag("BigAsteroids");
        newBigAsteroid.transform.position = new Vector2(CameraBordersChecker.screenInCameraCoordsX + 20f,
            CameraBordersChecker.screenInCameraCoordsY + 20f);

        SetUpNewAsteroid(newBigAsteroid);
    }

    public static void SpawnSmallAsteroid(Transform spawnPoint)
    {
        var newSmallAsteroid = Pool.GetElementFromPoolWithTag("SmallAsteroids");
        newSmallAsteroid.transform.position = spawnPoint.position;

        SetUpNewAsteroid(newSmallAsteroid);
    }

    private static void SetUpNewAsteroid(GameObject newAsteroid)
    {
        var randomForceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        var randomForceValue = Random.Range(50f, 200f);
        newAsteroid.GetComponent<Rigidbody2D>().AddForce(randomForceDirection * randomForceValue, ForceMode2D.Force);

        newAsteroid.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
    }
}