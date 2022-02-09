using System;
using UnityEngine;

namespace ObjectPool
{
    [AddComponentMenu("Object Pool/Pool element/Asteroid")]
    public class Asteroid : PoolElement
    {
        // split when collide with bullet
        // get damage when collide with bullet
        // destroy when hp is lover then 0
        // Moves randomly
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Bullet")
            {
                gameObject.SetActive(false);
            }
        }
    }
}