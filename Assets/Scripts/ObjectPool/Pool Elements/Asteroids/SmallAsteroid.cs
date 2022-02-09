using UnityEngine;

namespace ObjectPool
{
    [AddComponentMenu("Object Pool/Pool element/BigAsteroid")]
    public class SmallAsteroid : Asteroid
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Bullet") gameObject.SetActive(false);
        }
    }
}