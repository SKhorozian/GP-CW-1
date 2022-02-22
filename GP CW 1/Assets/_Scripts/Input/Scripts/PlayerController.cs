using SKhorozian.GPCW.Input;
using UnityEngine;

namespace SKhorozian.GPCW.Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterMovement characterMovement;

        private void Start() {
            InputProvider.instance.OnDashInput.AddListener(characterMovement.Dash);
        }

        private void Update() {
            characterMovement.MoveInput = InputProvider.instance.MoveInputValue;
        }
    }
}