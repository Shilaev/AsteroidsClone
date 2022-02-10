using ObjectPool;
using UnityEngine;

public abstract class SpaceShip : PoolElement
{
    private int _hp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Asteroid")
        {
            gameObject.SetActive(false);
        }
    }
}