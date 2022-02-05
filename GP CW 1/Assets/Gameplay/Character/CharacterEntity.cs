using UnityEngine;

namespace SKhorozian.FPSController.Character
{
    [RequireComponent(typeof(CharacterCombat))]
    [RequireComponent(typeof(CharacterMovement))]
    public class CharacterEntity : MonoBehaviour
    {
        [SerializeField] private CharacterMovement characterMovement;
        [SerializeField] private CharacterCombat characterCombat;

    }
}