using UnityEngine;

namespace SKhorozian.FPSController.Character
{
    public abstract class CharacterMovement : MonoBehaviour
    {
        //References
        [SerializeField] protected Rigidbody rb;
        [SerializeField] protected Transform characterTransform;
        [SerializeField] private Transform orientation;

        [SerializeField] private MovementProperties properties;

        public bool IsGrounded { get; private set; }
        private void CheckGrounded () => IsGrounded = Physics.Raycast(characterTransform.position, Vector3.down , properties.HalfCharacterHeight + 0.1f, properties.groundLayer);

        protected abstract Vector2 MoveInput { get; }

        private void FixedUpdate() {
            CheckGrounded();
            Move(MoveInput);
            SetDrag();
        }

        private void SetDrag() {
            rb.drag = IsGrounded ? properties.groundDrag : properties.aerialDrag;
        }

        private void Move(Vector2 input)
        {
            input.Normalize();

            var speedMult = IsGrounded ? properties.moveSpeed : properties.moveSpeed * properties.aerialSpeedMultiplier;
            input *= speedMult;
            var moveForce = orientation.forward * input.y + orientation.right * input.x;
            
            rb.AddForce(moveForce, ForceMode.Acceleration);
        }
    
        protected void TryJump() {
            if (IsGrounded) Jump();
            else UngroundedJump();
        }

        private void Jump() {
            var jumpPower = Mathf.Sqrt(-2f * Physics.gravity.y * properties.jumpHeight);
            rb.AddForce(jumpPower * Vector3.up, ForceMode.VelocityChange);
        }

        private void UngroundedJump() {
            
        }
    }
}