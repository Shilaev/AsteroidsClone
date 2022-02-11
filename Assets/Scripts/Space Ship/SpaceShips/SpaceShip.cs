using UnityEngine;
using UnityEngine.Events;

public abstract class SpaceShip : MonoBehaviour
{
    public int Hp { get; private set; }
    private int _currentHp;

    public UnityEvent OnHpChanged;
    public UnityEvent OnShipDestroyed;

    private void Awake()
    {
        Hp = 2;
        _currentHp = Hp;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (_currentHp != Hp)
        {
            OnHpChanged?.Invoke();
            _currentHp = Hp;
        }

        if (Hp <= 0)
        {
            OnShipDestroyed?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Asteroid") Hp--;
    }

    private void ResetSpaceShip()
    {
        gameObject.SetActive(true);
        transform.position = Vector3.zero;
        transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.rotation = Quaternion.identity;
    }
}