using System;
using ObjectPool;
using UnityEngine;
using UnityEngine.Events;

public abstract class SpaceShip : MonoBehaviour
{
    [SerializeField] private int _hp;

    public int Hp => _hp;

    public UnityEvent OnHpChanged;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Asteroid")
        {
            _hp--;
            OnHpChanged?.Invoke();
        }
    }

    private void Update()
    {
        if (_hp<=0)
        {
            gameObject.SetActive(false);
        }
    }
}