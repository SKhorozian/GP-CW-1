using SKhorozian.GPCW.Combat;
using SKhorozian.GPCW.Input;
using UnityEngine;

namespace SKhorozian.GPCW.Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterMovement characterMovement;
        [SerializeField] private CharacterOrientation orientation;
        [SerializeField] private PlayerSwing playerSwing;
        
        private void Start() {
            InputProvider.instance.OnDashInput.AddListener(characterMovement.Dash);
            InputProvider.instance.OnPrimaryFireInput.AddListener(playerSwing.Swing);
        }

        private void Update() {
            characterMovement.MoveInput = InputProvider.instance.MoveInputValue;
            InputOrientation();
        }

        private void InputOrientation() {
            var mouseScreenPos = InputProvider.instance.MouseScreenPosition;
            mouseScreenPos /= new Vector2(Screen.width, Screen.height);
            mouseScreenPos = (mouseScreenPos - (Vector2.one/2)) * 2;
            
            orientation.SetRotation(mouseScreenPos);
        }
    }
}