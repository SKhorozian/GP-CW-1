using UnityEngine;

namespace SKhorozian.FPSController.Character
{
    public class Hurtbox : MonoBehaviour
    {
        [SerializeField] private CharacterEntity characterEntity;
        public CharacterEntity CharacterEntity => characterEntity;
    }
}