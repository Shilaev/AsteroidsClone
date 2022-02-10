using ObjectPool;
using UnityEngine;

[AddComponentMenu("Controllers/SpaceShipController")]
public class SimpleSpaceShipController : MonoBehaviour
{
    [Range(0f, 1000f)] [SerializeField] private float _movementSpeed = 1000f;
    [Range(0f, 1000f)] [SerializeField] private float _rotationSpeed = 500;
    [Range(0f, 100f)] [SerializeField] private float _bulletVelocity = 20f;
    [SerializeField] private SpaceShip _spaceShip;

    private Transform _aim;
    private InputSystem _input;

    private void Awake()
    {
        _spaceShip = GetComponent<SpaceShip>();
        _aim = _spaceShip.GetComponent<Transform>().GetChild(0);

        _input = new InputSystem();
        _input.SpaceShip.SimpleShoot.performed += ctx => HandleFire();
    }

    private void Update()
    {
        HandlePowerUp();
        HandleRotation();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void HandleRotation()
    {
        var isRotationLeftHeld = _input.SpaceShip.RotationLeft.ReadValue<float>() > 0.1f;
        var isRotationRightHeld = _input.SpaceShip.RotationRight.ReadValue<float>() > 0.1f;

        if (isRotationLeftHeld) _spaceShip.GetComponent<Transform>().Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
        if (isRotationRightHeld) _spaceShip.GetComponent<Transform>().Rotate(Vector3.back, _rotationSpeed * Time.deltaTime);
    }

    private void HandlePowerUp()
    {
        var isPowerUpHeld = _input.SpaceShip.PowerUp.ReadValue<float>() > 0.1f;

        if (isPowerUpHeld)
        {
            var _spaceShipRB = _spaceShip.GetComponent<Rigidbody2D>();
            _spaceShipRB.AddRelativeForce(Vector2.up * Time.deltaTime * _movementSpeed, ForceMode2D.Force);
        }
    }


    private void HandleFire()
    {
        var spawnObject = Pool.GetElementFromPool("Bullet");
        spawnObject.transform.position = _aim.position;
        spawnObject.GetComponent<Rigidbody2D>().velocity = transform.up * _bulletVelocity;
    }
}