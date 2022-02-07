using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShipController : MonoBehaviour
{
    [Range(0f, 1000f)] [SerializeField] private float _movementSpeed = 1000f;
    [Range(0f, 1000f)] [SerializeField] private float _rotationSpeed = 500;
    [Range(0f, 100f)] [SerializeField] private float bulletVelocity = 40f;
    private InputSystem _input;
    private Transform _spaceShip;

    private void Awake()
    {
        _spaceShip = transform;
        _input = new InputSystem();
    }

    private void Update()
    {
        HandlePowerUp();
        HandleRotation();
        HandleFire();
    }

    private void HandleRotation()
    {
        var isRotationLeftHeld = _input.SpaceShip.RotationLeft.ReadValue<float>() > 0.1f;
        var isRotationRightHeld = _input.SpaceShip.RotationRight.ReadValue<float>() > 0.1f;

        if (isRotationLeftHeld) _spaceShip.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);

        if (isRotationRightHeld) _spaceShip.Rotate(Vector3.back, _rotationSpeed * Time.deltaTime);
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
        var aim = _spaceShip.GetChild(0);
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            var spawnObject = PoolSpawner.instance.SpawnPoolObjectWithTag("bullet");
            spawnObject.transform.position = aim.position;

            spawnObject.GetComponent<Rigidbody2D>().velocity = transform.up * bulletVelocity;
        }
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}