using System;
using CameraFeatures;
using UnityEngine;

namespace ObjectPool
{
    [AddComponentMenu("Object Pool/Pool element/Bullet")]
    public class Bullet : PoolElement
    {
        private void Update()
        {
            if (CameraBordersChecker.isOutOfBorders(transform)) gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            gameObject.SetActive(false);
        }
    }
}