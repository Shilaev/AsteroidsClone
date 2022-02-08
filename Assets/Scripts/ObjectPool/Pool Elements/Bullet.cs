using UnityEngine;

namespace ObjectPool
{
    [AddComponentMenu("Object Pool/Pool element/Bullet")]
    public class Bullet : PoolElement
    {
        // destroy when collide with something
        private void OnCollisionEnter2D(Collision2D other)
        {
            gameObject.SetActive(false);
        }
    }
}