using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPool;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class AsteroidsSpawner : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.fKey.wasReleasedThisFrame)
        {
            var elem = Pool.GetElementFromPoolWithTag("asteroids");
            elem.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            elem.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        }
    }
}
