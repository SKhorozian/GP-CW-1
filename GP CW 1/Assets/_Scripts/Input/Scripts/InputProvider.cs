using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace SKhorozian.GPCW.Input {
    public class InputProvider : MonoSingleton<InputProvider>
    {
        //Input Actions
        private PlayerInput _playerInput;

        private new void Awake () {
            base.Awake();
            
            //Create Player Input instance
            _playerInput = new PlayerInput ();
            _playerInput.Enable();
            
            //Register Events
            _playerInput.Player.Movement.performed += MoveInput;
            _playerInput.Player.Movement.canceled += MoveInput;

            _playerInput.Player.Dash.performed += DashInput;
            
            _playerInput.Player.PrimaryFire.performed += PrimaryFireInput;

            _playerInput.Player.MouseScreenPosition.performed += MouseScreenPositionInput;
            _playerInput.Player.MouseScreenPosition.canceled += MouseScreenPositionInput;
        }

        #region Input Listeners

        public Vector2 MoveInputValue { get; private set; }
        private void MoveInput (InputAction.CallbackContext ctx) {
            MoveInputValue = ctx.ReadValue<Vector2>();
        }

        public UnityEvent OnPrimaryFireInput;
        private void PrimaryFireInput(InputAction.CallbackContext ctx) {
            OnPrimaryFireInput?.Invoke();
        }

        public UnityEvent OnDashInput;
        private void DashInput(InputAction.CallbackContext ctx) {
            OnDashInput?.Invoke();
        }

        public Vector2 MouseScreenPosition { get; private set; }
        private void MouseScreenPositionInput(InputAction.CallbackContext ctx) {
            MouseScreenPosition = ctx.ReadValue<Vector2>();
        }

        #endregion

    }

}