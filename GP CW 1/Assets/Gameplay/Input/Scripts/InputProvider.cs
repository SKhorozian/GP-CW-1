using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace SKhorozian.TennisGame.Input {
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
            
            _playerInput.Player.PrimaryFire.started += PrimaryFireInput;
            _playerInput.Player.PrimaryFire.performed += PrimaryFireInput;
            _playerInput.Player.PrimaryFire.canceled += PrimaryFireInput;
        }

        #region Input Listeners

        public Vector2 MoveInputValue { get; private set; }
        private void MoveInput (InputAction.CallbackContext ctx) {
            MoveInputValue = ctx.ReadValue<Vector2>();
        }
        

        public UnityEvent OnPrimaryFireInput;
        public bool PrimaryFireHeldDown { get; private set; }
        private void PrimaryFireInput(InputAction.CallbackContext ctx) {
            if (ctx.performed) OnPrimaryFireInput?.Invoke();

            PrimaryFireHeldDown = !ctx.canceled;
        }

        public UnityEvent OnDashInput;
        private void DashInput(InputAction.CallbackContext ctx) {
            OnDashInput?.Invoke();
        }

        #endregion

    }

}