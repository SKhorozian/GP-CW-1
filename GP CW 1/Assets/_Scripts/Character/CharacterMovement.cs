using UnityEngine;
using UnityEngine.Events;

namespace SKhorozian.GPCW.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [Space(10)]
        //References
        [SerializeField] private Rigidbody rb;

        [SerializeField] private MovementProperties properties;

        //Stats
        [SerializeField] private float currentStamina;

        public void Start() {
            currentStamina = properties.MaxStamina;
        }

        public Vector2 MoveInput { get; set; }
        private void FixedUpdate() {
            Move(MoveInput);
            SetDrag();
            
            RegenerateStamina(properties.StaminaRegenRate * Time.deltaTime);
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
            if (currentStamina < properties.DashCost) return;
            if (input.magnitude == 0) return;
            
            input.Normalize();

            var dashForce = new Vector3(input.x, 0, input.y);
            dashForce *= properties.DashPower;

            rb.AddForce(dashForce, ForceMode.VelocityChange);
            
            ConsumeStamina(properties.DashCost);
        }

        
        private void RegenerateStamina(float amount) {
            currentStamina += amount;
            currentStamina = Mathf.Clamp(currentStamina, 0, properties.MaxStamina);
            
            OnStaminaChange?.Invoke(currentStamina / properties.MaxStamina);
        }
        
        private void ConsumeStamina(float amount) {
            currentStamina -= amount;
            currentStamina = Mathf.Clamp(currentStamina, 0, properties.MaxStamina);
            
            OnStaminaChange?.Invoke(currentStamina / properties.MaxStamina);
        }

        #region Events
        [Space (20)]
        [SerializeField] private UnityEvent<float> OnStaminaChange;
        public void RegisterForOnStaminaChange(UnityAction<float> action) => OnStaminaChange.AddListener(action);


        #endregion

    }
}