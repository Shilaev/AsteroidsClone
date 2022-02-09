using UnityEngine;

namespace ObjectPool
{
    [AddComponentMenu("Object Pool/Pool element/BigAsteroid")]
    public class BigAsteroid : Asteroid
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Bullet")
            {
                AsteroidsSpawner.SpawnSmallAsteroid(transform);
                AsteroidsSpawner.SpawnSmallAsteroid(transform);
                gameObject.SetActive(false);
            }
        }
    }
}