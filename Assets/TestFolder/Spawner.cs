using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private void Update()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Spawn();
        }

        if (Mouse.current.rightButton.wasReleasedThisFrame)
        {
            GameObject spawnObject = ObjectPool._instance.GetActivePooledObject();
            spawnObject.SetActive(false);
        }
    }

    public void Spawn()
    {
        GameObject spawnObject = ObjectPool._instance.GetPooledObject();

        if (spawnObject != null)
        {
            spawnObject.SetActive(true);

            var rand = Random.Range(-2, 2);
            var rand2 = Random.Range(-2, 2);
            spawnObject.transform.position = new Vector3(rand, rand2);

            var randC1 = Random.ColorHSV();
            spawnObject.GetComponent<SpriteRenderer>().color = randC1;
        }
    }
}
