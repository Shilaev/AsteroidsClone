using System;
using CameraFeatures;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace ObjectPool
{
    [AddComponentMenu("Object Pool/Pool element/Asteroid")]
    public class Asteroid : PoolElement
    {
        // split when collide with bullet
        // get damage when collide with bullet
        // destroy when hp is lover then 0
        // Moves randomly

        private UnityEvent myEvent;

        private float _hp;

        private void Start()
        {
            myEvent.AddListener(AsteroidsSpawner.SpawnSmallAsteroid);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Bullet")
            {
                gameObject.SetActive(false);
                myEvent?.Invoke();
            }
        }

        private void OnEnable()
        {

            transform.position = new Vector2(CameraBordersChecker.screenInCameraCoordsX + 20f,
                CameraBordersChecker.screenInCameraCoordsY + 20f);

            var randomForceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            GetComponent<Rigidbody2D>().AddForce(randomForceDirection * 2, ForceMode2D.Impulse);

            GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        }

    }
}