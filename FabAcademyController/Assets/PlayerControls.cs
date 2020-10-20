// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""gamePlay"",
            ""id"": ""4d911097-7aed-4cb8-90a3-896e38bbe7e2"",
            ""actions"": [
                {
                    ""name"": ""fire"",
                    ""type"": ""Button"",
                    ""id"": ""545afe01-bba5-4d03-85da-045a747766df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cde4c4b2-a604-48eb-b7ca-746da1e6fd56"",
                    ""path"": ""<CustomDevice>/firstButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // gamePlay
        m_gamePlay = asset.FindActionMap("gamePlay", throwIfNotFound: true);
        m_gamePlay_fire = m_gamePlay.FindAction("fire", throwIfNotFound: true);
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

    // gamePlay
    private readonly InputActionMap m_gamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_gamePlay_fire;
    public struct GamePlayActions
    {
        private @PlayerControls m_Wrapper;
        public GamePlayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @fire => m_Wrapper.m_gamePlay_fire;
        public InputActionMap Get() { return m_Wrapper.m_gamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @fire.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
                @fire.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
                @fire.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @fire.started += instance.OnFire;
                @fire.performed += instance.OnFire;
                @fire.canceled += instance.OnFire;
            }
        }
    }
    public GamePlayActions @gamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnFire(InputAction.CallbackContext context);
    }
}
