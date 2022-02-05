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

            _playerInput.Player.PrimaryFire.started += PrimaryFireInput;
            _playerInput.Player.PrimaryFire.performed += PrimaryFireInput;
            _playerInput.Player.PrimaryFire.canceled += PrimaryFireInput;
            
            //Disable Mouse
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        #region Input Listeners

        public Vector2 MoveInputValue { get; private set; }
        private void MoveInput (InputAction.CallbackContext ctx) {
            MoveInputValue = ctx.ReadValue<Vector2>();
        }

        public UnityEvent OnJumpInput;
        private void JumpInput (InputAction.CallbackContext ctx) {
            OnJumpInput?.Invoke();
        }

        public UnityEvent<Vector2> OnLookInput;
        private void LookInput(InputAction.CallbackContext ctx) { 
            var inputValue = ctx.ReadValue<Vector2>();
            OnLookInput?.Invoke(inputValue);
        }

        public UnityEvent OnPrimaryFireInput;
        public bool PrimaryFireHeldDown { get; private set; }
        private void PrimaryFireInput(InputAction.CallbackContext ctx) {
            if (ctx.performed) OnPrimaryFireInput?.Invoke();

            PrimaryFireHeldDown = !ctx.canceled;
        }
        
        public UnityEvent OnSecondaryFireInput;
        public bool SecondaryFireHeldDown { get; private set; }
        private void SecondaryFireInput(InputAction.CallbackContext ctx) {
            if (ctx.performed) OnSecondaryFireInput?.Invoke();

            SecondaryFireHeldDown = !ctx.canceled;
        }

        #endregion


        #region Singleton Pattern
        private static InputManager _instance;
        public static InputManager Instance {
            get {
                if (_instance) return _instance;
                
                _instance = FindObjectOfType<InputManager> ();
                
                if (!_instance) Debug.LogError("{InputManager} Instance of type [InputManager] not found!");

                return _instance;
            }
        }
        #endregion


    }

}