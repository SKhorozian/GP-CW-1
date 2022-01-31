using UnityEngine;

namespace SKhorozian.FPSController.Character
{
    [CreateAssetMenu (fileName = "New Movement Properties", menuName = "FPS Game/Character/Create new Movement Properties")]
    public class MovementProperties : ScriptableObject
    {
        public float characterHeight = 1.75f;
        public float HalfCharacterHeight => characterHeight * 0.5f;
        
        public LayerMask groundLayer;

        [Space (10)]
        public float moveSpeed = 25f;
        public float aerialSpeedMultiplier = 0.3f; 
        
        public float groundDrag = 4f;
        public float aerialDrag = 1f;

        public float jumpHeight = 2f;
    }
}