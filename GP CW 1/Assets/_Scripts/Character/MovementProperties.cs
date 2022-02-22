using UnityEngine;

namespace SKhorozian.GPCW.Character
{
    [CreateAssetMenu (fileName = "New Movement Properties", menuName = "FPS Game/Character/Create new Movement Properties")]
    public class MovementProperties : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed {get; private set; }
        [field: SerializeField] public float GroundDrag { get; private set; }
        
        [field: SerializeField, Space (10)] public float DashPower {get; private set; }
        [field: SerializeField] public float MaxStamina { get; private set; }
        [field: SerializeField] public float StaminaRegenRate { get; private set; }
        [field: SerializeField] public float DashCost { get; private set; }

    }
}