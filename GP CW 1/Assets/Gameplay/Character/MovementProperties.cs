using UnityEngine;

namespace SKhorozian.TennisGame.Character
{
    [CreateAssetMenu (fileName = "New Movement Properties", menuName = "FPS Game/Character/Create new Movement Properties")]
    public class MovementProperties : ScriptableObject
    {
        [SerializeField] private float characterHeight = 1.75f;
        public float CharacterHeight => characterHeight;

        [Space (10)]
        [SerializeField] private float moveSpeed = 25f;
        public float MoveSpeed => moveSpeed;
        
        [SerializeField] private float groundDrag = 4f;
        public float GroundDrag => groundDrag;
        
        [Space (10)]
        [SerializeField] private float dashPower = 25f;
        public float DashPower => dashPower;
        
        [SerializeField] private float maxStamina = 100;
        public float MaxStamina => maxStamina;
        
        [SerializeField] private float staminaRegenRate = 20;
        public float StaminaRegenRate => staminaRegenRate;
        
        [SerializeField] private float dashCost = 25f;
        public float DashCost => dashCost;

    }
}