using System;
using Unity.Mathematics;
using UnityEngine;

namespace SKhorozian.TennisGame.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [Space(10)]
        //References
        [SerializeField] private Rigidbody rb;

        [SerializeField] private MovementProperties properties;

        //Stats
        private float stamina;

        public void Start() {
            stamina = properties.MaxStamina;
        }

        public Vector2 MoveInput { get; set; }
        private void FixedUpdate() {
            Move(MoveInput);
            SetDrag();
            RegenerateStamina();
        }

        private void RegenerateStamina() {
            stamina += properties.StaminaRegenRate * Time.deltaTime;
            stamina = Mathf.Clamp(stamina, 0, properties.MaxStamina);
        }

        private void SetDrag() {
            rb.drag = properties.GroundDrag;
        }

        private void Move(Vector2 input) {
            input.Normalize();
            
            var moveForce = new Vector3(input.x, 0, input.y);
            moveForce *= properties.MoveSpeed;
            
            rb.AddForce(moveForce, ForceMode.Acceleration);
        }

        public void Dash() => Dash(MoveInput);
        
        private void Dash(Vector2 input) {
            if (input.magnitude == 0) return;
            
            input.Normalize();

            var dashForce = new Vector3(input.x, 0, input.y);
            dashForce *= properties.DashPower;

            rb.AddForce(dashForce, ForceMode.VelocityChange);
        }

        
        private void RegenerateStamina(float amount) {
            stamina += amount;
            stamina = Mathf.Clamp(stamina, 0, properties.MaxStamina);
        }
        
        private void ConsumeStamina(float amount) {
            RegenerateStamina(-amount);
        }

    }
}