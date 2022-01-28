using System;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    private InputSystem _input;
    private Transform _spaceShip;

    private void Awake()
    {
        _spaceShip = this.transform;
        _input = new InputSystem();
    }

    private void Update()
    {
        HandlePowerUp();
        HandleRotation();
    }

    private void HandleRotation()
    {
        bool isRotationLeftHeld = _input.SpaceShip.RotationLeft.ReadValue<float>() > 0.1f;
        bool isRotationRightHeld = _input.SpaceShip.RotationRight.ReadValue<float>() > 0.1f;

        if (isRotationLeftHeld)
        {
            _spaceShip.Rotate(new Vector3(0, 0, 1), 2.0f);
        }

        if (isRotationRightHeld)
        {
            _spaceShip.Rotate(new Vector3(0, 0, -1), 2.0f);

        }
    }

    private void HandlePowerUp()
    {
        bool isPowerUpHeld = _input.SpaceShip.PowerUp.ReadValue<float>() > 0.1f;

        if (isPowerUpHeld)
        {
            Debug.Log("hello");
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