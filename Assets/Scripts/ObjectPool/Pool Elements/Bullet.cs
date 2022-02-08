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

        // destroy when collide with something
        private void OnCollisionEnter2D(Collision2D other)
        {
            gameObject.SetActive(false);
        }
    }
}