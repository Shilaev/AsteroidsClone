// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""SpaceShip"",
            ""id"": ""8e5a551d-9c31-4aed-aae1-6eaa268e91c4"",
            ""actions"": [
                {
                    ""name"": ""PowerUp"",
                    ""type"": ""Button"",
                    ""id"": ""9a769eb0-0605-4fa1-9d22-807e5480cd2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""35cf7884-58bf-490a-9ad0-879e54c17d63"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PowerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // SpaceShip
        m_SpaceShip = asset.FindActionMap("SpaceShip", throwIfNotFound: true);
        m_SpaceShip_PowerUp = m_SpaceShip.FindAction("PowerUp", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // SpaceShip
    private readonly InputActionMap m_SpaceShip;
    private ISpaceShipActions m_SpaceShipActionsCallbackInterface;
    private readonly InputAction m_SpaceShip_PowerUp;
    public struct SpaceShipActions
    {
        private @InputSystem m_Wrapper;
        public SpaceShipActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @PowerUp => m_Wrapper.m_SpaceShip_PowerUp;
        public InputActionMap Get() { return m_Wrapper.m_SpaceShip; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpaceShipActions set) { return set.Get(); }
        public void SetCallbacks(ISpaceShipActions instance)
        {
            if (m_Wrapper.m_SpaceShipActionsCallbackInterface != null)
            {
                @PowerUp.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnPowerUp;
                @PowerUp.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnPowerUp;
                @PowerUp.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnPowerUp;
            }
            m_Wrapper.m_SpaceShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PowerUp.started += instance.OnPowerUp;
                @PowerUp.performed += instance.OnPowerUp;
                @PowerUp.canceled += instance.OnPowerUp;
            }
        }
    }
    public SpaceShipActions @SpaceShip => new SpaceShipActions(this);
    public interface ISpaceShipActions
    {
        void OnPowerUp(InputAction.CallbackContext context);
    }
}
