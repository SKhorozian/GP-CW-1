using UnityEngine;

namespace SKhorozian.CoreGameplay.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData weaponData;
        public WeaponData WeaponData => weaponData;
        
        [Space(10)]
        [SerializeField] private WeaponFire primaryFire;
        [SerializeField] private WeaponFire secondaryFire;

        private WeaponActionData NewWeaponActionData => new WeaponActionData {
            Direction = transform.forward,
            FirePoint = transform.position
        };

        public void FirePrimary() {
            primaryFire?.DoAction(NewWeaponActionData);
        }

        public void FireSecondary() {
            secondaryFire?.DoAction(NewWeaponActionData);
        }
    }
}
