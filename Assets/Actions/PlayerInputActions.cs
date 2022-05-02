//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Actions/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""2a50fbf7-64f0-4b32-bbd1-ebab7b3df3da"",
            ""actions"": [
                {
                    ""name"": ""Move Paddle Left"",
                    ""type"": ""Button"",
                    ""id"": ""b3cd9f6e-b0b8-4123-b4c9-c9d97ae3a57d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move Paddle Right"",
                    ""type"": ""Button"",
                    ""id"": ""fec3d2dc-e460-4f6f-9753-853fa7a8f8cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""baa2758f-961b-473c-85cd-02564ba19957"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Paddle Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fd58ef7-98af-4251-9ffc-253f42dd8093"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Paddle Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffd7b8f1-dc38-44ee-8600-0c04cedfab5c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Paddle Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4f48b54-7a59-42e1-8d18-599ed178d80e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Paddle Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MovePaddleLeft = m_Player.FindAction("Move Paddle Left", throwIfNotFound: true);
        m_Player_MovePaddleRight = m_Player.FindAction("Move Paddle Right", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MovePaddleLeft;
    private readonly InputAction m_Player_MovePaddleRight;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovePaddleLeft => m_Wrapper.m_Player_MovePaddleLeft;
        public InputAction @MovePaddleRight => m_Wrapper.m_Player_MovePaddleRight;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MovePaddleLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovePaddleLeft;
                @MovePaddleLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovePaddleLeft;
                @MovePaddleLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovePaddleLeft;
                @MovePaddleRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovePaddleRight;
                @MovePaddleRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovePaddleRight;
                @MovePaddleRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovePaddleRight;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovePaddleLeft.started += instance.OnMovePaddleLeft;
                @MovePaddleLeft.performed += instance.OnMovePaddleLeft;
                @MovePaddleLeft.canceled += instance.OnMovePaddleLeft;
                @MovePaddleRight.started += instance.OnMovePaddleRight;
                @MovePaddleRight.performed += instance.OnMovePaddleRight;
                @MovePaddleRight.canceled += instance.OnMovePaddleRight;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovePaddleLeft(InputAction.CallbackContext context);
        void OnMovePaddleRight(InputAction.CallbackContext context);
    }
}