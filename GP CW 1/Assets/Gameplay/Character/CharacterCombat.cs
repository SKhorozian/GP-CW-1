using SKhorozian.CoreGameplay.Weapons;
using UnityEngine;
using UnityEngine.Events;

namespace SKhorozian.FPSController.Character
{
    public abstract class CharacterCombat : MonoBehaviour
    {
        [Header("Weapons")] 
        [SerializeField] private Weapon[] weapons;
        public int CurrentWeaponIndex { get; private set; }
        private Weapon CurrentWeaponData => weapons[CurrentWeaponIndex];

        [Header("Events")] 
        public UnityEvent<Weapon, int> OnWeaponSwap;
        public UnityEvent<Weapon> OnWeaponPrimaryFire;
        public UnityEvent<Weapon> OnWeaponSecondaryFire;

        [Header("Opponent Tag")] 
        [SerializeField] private string opponentTag;
        
        protected void SwapWeapon(int index) {
            CurrentWeaponIndex = Mathf.Clamp(index, 0, weapons.Length);

            OnWeaponSwap?.Invoke(CurrentWeaponData, CurrentWeaponIndex);
        }

        protected void FireWeaponPrimary() {
            CurrentWeaponData.FirePrimary();
            OnWeaponPrimaryFire?.Invoke(CurrentWeaponData);
        }

        protected void FireWeaponSecondary() {
            CurrentWeaponData.FireSecondary();
            OnWeaponSecondaryFire?.Invoke(CurrentWeaponData);
        }

    }
}
