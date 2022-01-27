using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace SKhorozian.FPSController.Input {
    public class InputManager : MonoBehaviour
    {
        //Input Actions
        private PlayerInput _playerInput;

        void Awake () { 
            //Singleton Pattern
            if (Instance != this)
                DestroyImmediate(gameObject);
            
            _instance = this;

            //Create Player Input instance
            _playerInput = new PlayerInput ();
            _playerInput.Enable();
            
            //Register Events
            _playerInput.Player.Movement.performed += MoveInput;
            _playerInput.Player.Movement.canceled += MoveInput;
            _playerInput.Player.Jump.performed += JumpInput;
            _playerInput.Player.Look.performed += LookInput;
            
            //Disable Mouse
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        #region Input Listeners

        public Vector2 MoveInputValue { get; private set; }
        void MoveInput (InputAction.CallbackContext ctx) {
            MoveInputValue = ctx.ReadValue<Vector2>();
        }

        public UnityEvent OnJumpInput;
        void JumpInput (InputAction.CallbackContext ctx) {
            OnJumpInput?.Invoke();
        }

        public UnityEvent<Vector2> OnLookInput;
        void LookInput(InputAction.CallbackContext ctx) { 
            Vector2 inputValue = ctx.ReadValue<Vector2>();
            OnLookInput?.Invoke(inputValue);
        }
        #endregion


        #region Singleton Pattern
        private static InputManager _instance;
        public static InputManager Instance {
            get {
                if (!_instance) { 
                    _instance = FindObjectOfType<InputManager> ();

                    if (!_instance) Debug.LogError("{InputManager} Instance of type \"InputManager\" not found!");
                }

                return _instance;
            }
        }
        #endregion


    }

}