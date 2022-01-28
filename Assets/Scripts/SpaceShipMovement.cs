using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    private InputSystem _input;

    private void Awake()
    {
        _input = new InputSystem();
    }

    private void Start()
    {
        _input.SpaceShip.PowerUp.performed += ctx => { Debug.Log("Hello"); };
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