// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/FPS/PlayerFPS.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerFPS : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerFPS()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerFPS"",
    ""maps"": [
        {
            ""name"": ""PlayerInput"",
            ""id"": ""34d51d11-a890-4eca-9904-63c51ec9e64f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""5506b392-6a9e-4229-b3ec-ff79d93a3cfe"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""94e768f8-a966-4963-aa49-37d4fc7c6763"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""4289e2b4-7d2f-47a4-a098-2843f89d0940"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotationX"",
                    ""type"": ""Value"",
                    ""id"": ""74d2d6fe-8927-4180-b60f-18d55acd96d8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotationY"",
                    ""type"": ""Value"",
                    ""id"": ""2a2dfe7c-244f-4c96-9304-2f127f60fbf2"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""dc84c2a4-839c-452a-80ad-37367d273357"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WalkWASD"",
                    ""id"": ""6376f9e7-4bb2-4a7c-939f-7771f42235cb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b404a926-4cd6-46f8-b6b8-6e83f7747392"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4043dada-9202-4e56-a1e3-b7065d946d3e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5aa4ef80-95a8-4fbe-9c00-f8756f91ba43"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""da33c0c0-8036-446d-804a-2001c46cc411"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0a85b570-bb0d-4b7c-a8af-0f8518914103"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b85a642-9b43-4480-9f5b-149615d9bfac"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7644ba8e-3052-4c92-83ea-f389ff8a080e"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e6eaf3a-fd0d-475a-8176-6328ee2d1714"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a072737b-f8e9-468a-98ff-a49227fbecc6"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3d6b446-31ee-49de-9e3c-9545a4df8457"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RotationX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bd32873-8b3d-43e0-8377-cd35039ec7f7"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""RotationX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b4ceb9a-af5c-4a49-bf2d-b3dac01aba73"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""RotationY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b65b92a9-77ed-4b7c-95d6-09562c799b3b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ffb340f-85eb-4a32-86bc-e9f01de41534"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerInput
        m_PlayerInput = asset.FindActionMap("PlayerInput", throwIfNotFound: true);
        m_PlayerInput_Move = m_PlayerInput.FindAction("Move", throwIfNotFound: true);
        m_PlayerInput_Shoot = m_PlayerInput.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerInput_Reload = m_PlayerInput.FindAction("Reload", throwIfNotFound: true);
        m_PlayerInput_RotationX = m_PlayerInput.FindAction("RotationX", throwIfNotFound: true);
        m_PlayerInput_RotationY = m_PlayerInput.FindAction("RotationY", throwIfNotFound: true);
        m_PlayerInput_Jump = m_PlayerInput.FindAction("Jump", throwIfNotFound: true);
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

    // PlayerInput
    private readonly InputActionMap m_PlayerInput;
    private IPlayerInputActions m_PlayerInputActionsCallbackInterface;
    private readonly InputAction m_PlayerInput_Move;
    private readonly InputAction m_PlayerInput_Shoot;
    private readonly InputAction m_PlayerInput_Reload;
    private readonly InputAction m_PlayerInput_RotationX;
    private readonly InputAction m_PlayerInput_RotationY;
    private readonly InputAction m_PlayerInput_Jump;
    public struct PlayerInputActions
    {
        private @PlayerFPS m_Wrapper;
        public PlayerInputActions(@PlayerFPS wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerInput_Move;
        public InputAction @Shoot => m_Wrapper.m_PlayerInput_Shoot;
        public InputAction @Reload => m_Wrapper.m_PlayerInput_Reload;
        public InputAction @RotationX => m_Wrapper.m_PlayerInput_RotationX;
        public InputAction @RotationY => m_Wrapper.m_PlayerInput_RotationY;
        public InputAction @Jump => m_Wrapper.m_PlayerInput_Jump;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInputActions instance)
        {
            if (m_Wrapper.m_PlayerInputActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMove;
                @Shoot.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnShoot;
                @Reload.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnReload;
                @RotationX.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotationX;
                @RotationX.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotationX;
                @RotationX.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotationX;
                @RotationY.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotationY;
                @RotationY.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotationY;
                @RotationY.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnRotationY;
                @Jump.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @RotationX.started += instance.OnRotationX;
                @RotationX.performed += instance.OnRotationX;
                @RotationX.canceled += instance.OnRotationX;
                @RotationY.started += instance.OnRotationY;
                @RotationY.performed += instance.OnRotationY;
                @RotationY.canceled += instance.OnRotationY;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerInputActions @PlayerInput => new PlayerInputActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerInputActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnRotationX(InputAction.CallbackContext context);
        void OnRotationY(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
