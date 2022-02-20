using System;
using SKhorozian.TennisGame.Input;
using UnityEngine;

namespace SKhorozian.TennisGame.Character
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