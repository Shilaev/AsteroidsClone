using System;
using UnityEngine;
using UnityEngine.Events;

namespace ObjectPool
{
    public abstract class Asteroid : MonoBehaviour
    {
        private void Start()
        {
            GameManager.instance.OnGameStop.AddListener(delegate { gameObject.SetActive(false); });
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Bullet")
            {
                gameObject.SetActive(false);
                GameManager.instance.SubstractOneAsteroidFromUi();
            }
        }
    }
}