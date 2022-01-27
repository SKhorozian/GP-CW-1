using UnityEngine;

namespace SKhorozian.FPSController.Character
{
    public abstract class CharacterMovement : MonoBehaviour
    {
        //References
        [SerializeField] protected Rigidbody rb;
        [SerializeField] protected Transform characterTransform;
        
        // TODO place this in a ScriptableObject
        #region Properties
        
        [Space(10)] 
        [SerializeField] private float characterHeight = 1.75f;
        private float HalfCharacterHeight => characterHeight * 0.5f;
        
        [SerializeField] private LayerMask groundLayer;

        [Space (10)]
        [SerializeField] private float moveSpeed = 25f;
        [SerializeField] private float aerialSpeedMultiplier = 0.3f; 
        
        [SerializeField] private float groundDrag = 4f;
        [SerializeField] private float aerialDrag = 1f;

        [SerializeField] private float jumpHeight = 2f;
        
        #endregion

        [Space(10)]
        [SerializeField] private bool isGrounded;
        private void CheckGrounded () => isGrounded = Physics.Raycast(characterTransform.position, Vector3.down , HalfCharacterHeight + 0.1f, groundLayer);

        protected abstract Vector2 MoveInput { get; }

        private void FixedUpdate() {
            CheckGrounded();
            Move(MoveInput);
            SetDrag();
        }

        private void SetDrag() {
            rb.drag = isGrounded ? groundDrag : aerialDrag;
        }

        private void Move(Vector2 input)
        {
            input.Normalize();

            var speedMult = isGrounded ? moveSpeed : moveSpeed * aerialSpeedMultiplier;
            input *= speedMult;
            var moveForce = characterTransform.forward * input.y + characterTransform.right * input.x;
            
            rb.AddForce(moveForce, ForceMode.Acceleration);
        }
    
        protected void TryJump() {
            if (isGrounded) Jump();
            else UngroundedJump();
        }

        private void Jump() {
            var jumpPower = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
            rb.AddForce(jumpPower * Vector3.up, ForceMode.VelocityChange);
        }

        private void UngroundedJump() {
            
        }
    }
}