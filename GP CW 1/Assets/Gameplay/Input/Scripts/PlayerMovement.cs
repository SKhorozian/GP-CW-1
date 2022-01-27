using SKhorozian.FPSController.Character;
using UnityEngine;

namespace SKhorozian.FPSController.Input {
    public class PlayerMovement : CharacterMovement
    {
        private void Start()
        {
            InputManager.Instance.OnJumpInput.AddListener(TryJump);
        }

        protected override Vector2 MoveInput => InputManager.Instance.MoveInputValue;
    }

}
