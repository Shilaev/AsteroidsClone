using UnityEngine;

namespace ObjectPool
{
    public abstract class Asteroid : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Bullet")
            {
                gameObject.SetActive(false);
            }
        }
    }
}