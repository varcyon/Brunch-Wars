// GENERATED AUTOMATICALLY FROM 'Assets/Implemented/ShipInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class ShipInput : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public ShipInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ShipInput"",
    ""maps"": [
        {
            ""name"": ""GamePadGamePlay"",
            ""id"": ""59b2fece-f3d8-4cfc-9f46-50925efc2533"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""ebecb520-4e3f-445f-a592-ff7abb0ca970"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""2a9b7a62-35c3-4a97-a7a9-16fe270f8627"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reverse"",
                    ""type"": ""Button"",
                    ""id"": ""cb734884-43d0-4321-b7c6-39f6c696de03"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Phaser"",
                    ""type"": ""Button"",
                    ""id"": ""42a7524e-9dbc-47f1-bbad-a25e2f861ed4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2f1d9366-1cf1-4c56-8f01-c0d390cafcb7"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94a08a6a-51b2-4e79-b83c-b0bbd8208e2d"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a13a2cae-dcb1-4f89-a68c-cb07a6570130"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6079152-e2e4-4c19-94d2-36704ab8f929"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Phaser"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""KMGamePlay"",
            ""id"": ""6305db50-3c6e-4e95-8e47-440bacc9e46f"",
            ""actions"": [
                {
                    ""name"": ""Phaser"",
                    ""type"": ""Button"",
                    ""id"": ""ff79f1a4-f036-4d15-8776-320606d4f491"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reverse"",
                    ""type"": ""Button"",
                    ""id"": ""9cfe3c99-8696-4e22-a01f-e7e998d001e9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""a95701de-05fd-43e6-aa17-b972b3e86725"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d7bfeb0a-f15e-47d2-9e30-db62947e6ea4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d5a1a621-c29f-4d99-a941-16358039831e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Phaser"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6dcb9c51-8919-44c3-bbb2-dd1a2d444497"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e600910a-799e-4961-b2d7-075f9902521d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95c67863-6180-4d05-96a3-5cbd29366f72"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePadGamePlay
        m_GamePadGamePlay = asset.FindActionMap("GamePadGamePlay", throwIfNotFound: true);
        m_GamePadGamePlay_Move = m_GamePadGamePlay.FindAction("Move", throwIfNotFound: true);
        m_GamePadGamePlay_Forward = m_GamePadGamePlay.FindAction("Forward", throwIfNotFound: true);
        m_GamePadGamePlay_Reverse = m_GamePadGamePlay.FindAction("Reverse", throwIfNotFound: true);
        m_GamePadGamePlay_Phaser = m_GamePadGamePlay.FindAction("Phaser", throwIfNotFound: true);
        // KMGamePlay
        m_KMGamePlay = asset.FindActionMap("KMGamePlay", throwIfNotFound: true);
        m_KMGamePlay_Phaser = m_KMGamePlay.FindAction("Phaser", throwIfNotFound: true);
        m_KMGamePlay_Reverse = m_KMGamePlay.FindAction("Reverse", throwIfNotFound: true);
        m_KMGamePlay_Forward = m_KMGamePlay.FindAction("Forward", throwIfNotFound: true);
        m_KMGamePlay_Point = m_KMGamePlay.FindAction("Point", throwIfNotFound: true);
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

    // GamePadGamePlay
    private readonly InputActionMap m_GamePadGamePlay;
    private IGamePadGamePlayActions m_GamePadGamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePadGamePlay_Move;
    private readonly InputAction m_GamePadGamePlay_Forward;
    private readonly InputAction m_GamePadGamePlay_Reverse;
    private readonly InputAction m_GamePadGamePlay_Phaser;
    public struct GamePadGamePlayActions
    {
        private ShipInput m_Wrapper;
        public GamePadGamePlayActions(ShipInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GamePadGamePlay_Move;
        public InputAction @Forward => m_Wrapper.m_GamePadGamePlay_Forward;
        public InputAction @Reverse => m_Wrapper.m_GamePadGamePlay_Reverse;
        public InputAction @Phaser => m_Wrapper.m_GamePadGamePlay_Phaser;
        public InputActionMap Get() { return m_Wrapper.m_GamePadGamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePadGamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePadGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePadGamePlayActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_GamePadGamePlayActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_GamePadGamePlayActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_GamePadGamePlayActionsCallbackInterface.OnMove;
                Forward.started -= m_Wrapper.m_GamePadGamePlayActionsCallbackInterface.OnForward;
                Forward.performed -= m_Wrapper.m_GamePadGamePlayActionsCallbackInterface.OnForward;
                Forward.canceled -= m_Wrapper.m_GamePadGamePlayActionsCallbackInterface.OnForward;
                Reverse.started -= m_Wrapper.m_GamePadGamePlayActionsCallbackInterface.OnReverse;
                Reverse.performed -= m_Wrapper.m_GamePadGamePlayActionsCallbackInterface.OnReverse;
                Reverse.canceled -= m_Wrapper.m_GamePadGamePlayActionsCallbackInterface.OnReverse;
                Phaser.started -= m_Wrapper.m_GamePadGamePlayActionsCallbackInterface.OnPhaser;
                Phaser.performed -= m_Wrapper.m_GamePadGamePlayActionsCallbackInterface.OnPhaser;
                Phaser.canceled -= m_Wrapper.m_GamePadGamePlayActionsCallbackInterface.OnPhaser;
            }
            m_Wrapper.m_GamePadGamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Forward.started += instance.OnForward;
                Forward.performed += instance.OnForward;
                Forward.canceled += instance.OnForward;
                Reverse.started += instance.OnReverse;
                Reverse.performed += instance.OnReverse;
                Reverse.canceled += instance.OnReverse;
                Phaser.started += instance.OnPhaser;
                Phaser.performed += instance.OnPhaser;
                Phaser.canceled += instance.OnPhaser;
            }
        }
    }
    public GamePadGamePlayActions @GamePadGamePlay => new GamePadGamePlayActions(this);

    // KMGamePlay
    private readonly InputActionMap m_KMGamePlay;
    private IKMGamePlayActions m_KMGamePlayActionsCallbackInterface;
    private readonly InputAction m_KMGamePlay_Phaser;
    private readonly InputAction m_KMGamePlay_Reverse;
    private readonly InputAction m_KMGamePlay_Forward;
    private readonly InputAction m_KMGamePlay_Point;
    public struct KMGamePlayActions
    {
        private ShipInput m_Wrapper;
        public KMGamePlayActions(ShipInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Phaser => m_Wrapper.m_KMGamePlay_Phaser;
        public InputAction @Reverse => m_Wrapper.m_KMGamePlay_Reverse;
        public InputAction @Forward => m_Wrapper.m_KMGamePlay_Forward;
        public InputAction @Point => m_Wrapper.m_KMGamePlay_Point;
        public InputActionMap Get() { return m_Wrapper.m_KMGamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KMGamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IKMGamePlayActions instance)
        {
            if (m_Wrapper.m_KMGamePlayActionsCallbackInterface != null)
            {
                Phaser.started -= m_Wrapper.m_KMGamePlayActionsCallbackInterface.OnPhaser;
                Phaser.performed -= m_Wrapper.m_KMGamePlayActionsCallbackInterface.OnPhaser;
                Phaser.canceled -= m_Wrapper.m_KMGamePlayActionsCallbackInterface.OnPhaser;
                Reverse.started -= m_Wrapper.m_KMGamePlayActionsCallbackInterface.OnReverse;
                Reverse.performed -= m_Wrapper.m_KMGamePlayActionsCallbackInterface.OnReverse;
                Reverse.canceled -= m_Wrapper.m_KMGamePlayActionsCallbackInterface.OnReverse;
                Forward.started -= m_Wrapper.m_KMGamePlayActionsCallbackInterface.OnForward;
                Forward.performed -= m_Wrapper.m_KMGamePlayActionsCallbackInterface.OnForward;
                Forward.canceled -= m_Wrapper.m_KMGamePlayActionsCallbackInterface.OnForward;
                Point.started -= m_Wrapper.m_KMGamePlayActionsCallbackInterface.OnPoint;
                Point.performed -= m_Wrapper.m_KMGamePlayActionsCallbackInterface.OnPoint;
                Point.canceled -= m_Wrapper.m_KMGamePlayActionsCallbackInterface.OnPoint;
            }
            m_Wrapper.m_KMGamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Phaser.started += instance.OnPhaser;
                Phaser.performed += instance.OnPhaser;
                Phaser.canceled += instance.OnPhaser;
                Reverse.started += instance.OnReverse;
                Reverse.performed += instance.OnReverse;
                Reverse.canceled += instance.OnReverse;
                Forward.started += instance.OnForward;
                Forward.performed += instance.OnForward;
                Forward.canceled += instance.OnForward;
                Point.started += instance.OnPoint;
                Point.performed += instance.OnPoint;
                Point.canceled += instance.OnPoint;
            }
        }
    }
    public KMGamePlayActions @KMGamePlay => new KMGamePlayActions(this);
    public interface IGamePadGamePlayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnForward(InputAction.CallbackContext context);
        void OnReverse(InputAction.CallbackContext context);
        void OnPhaser(InputAction.CallbackContext context);
    }
    public interface IKMGamePlayActions
    {
        void OnPhaser(InputAction.CallbackContext context);
        void OnReverse(InputAction.CallbackContext context);
        void OnForward(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
    }
}
