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

        // Randomly move from A to way point B
        // when asteroid on way point B - generate new way point B

        private Transform targetPosition;

    }
}