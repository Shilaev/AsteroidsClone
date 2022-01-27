// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputSystem.inputactions'

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
            ""id"": ""e77081df-41f7-4b9c-9691-907db80c9a34"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""5c4060a6-71ee-473b-919b-debbdcbed14f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Button"",
                    ""id"": ""3ef0d28f-c226-4f2a-81fb-87210afd7790"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""891ee388-bddf-4a09-8997-58b5f544d43a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e66cfc0-1bd9-43ef-8ec3-c0133d8d1eea"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
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
        m_SpaceShip_Movement = m_SpaceShip.FindAction("Movement", throwIfNotFound: true);
        m_SpaceShip_Rotation = m_SpaceShip.FindAction("Rotation", throwIfNotFound: true);
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
    private readonly InputAction m_SpaceShip_Movement;
    private readonly InputAction m_SpaceShip_Rotation;
    public struct SpaceShipActions
    {
        private @InputSystem m_Wrapper;
        public SpaceShipActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_SpaceShip_Movement;
        public InputAction @Rotation => m_Wrapper.m_SpaceShip_Rotation;
        public InputActionMap Get() { return m_Wrapper.m_SpaceShip; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpaceShipActions set) { return set.Get(); }
        public void SetCallbacks(ISpaceShipActions instance)
        {
            if (m_Wrapper.m_SpaceShipActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnMovement;
                @Rotation.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnRotation;
            }
            m_Wrapper.m_SpaceShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
            }
        }
    }
    public SpaceShipActions @SpaceShip => new SpaceShipActions(this);
    public interface ISpaceShipActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
    }
}
