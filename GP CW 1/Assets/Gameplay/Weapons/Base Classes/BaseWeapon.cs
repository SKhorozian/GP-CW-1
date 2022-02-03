using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SKhorozian.CoreGameplay.Weapons
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Create new Weapon")]
    public class BaseWeapon : ScriptableObject
    {
        [SerializeField] private float fireRate;
        public float FireRate => fireRate;

        [Space(10)]
        [SerializeField] private float firstShotAccuracy;
        public float FirstShotAccuracy => firstShotAccuracy;

        [SerializeField] private float scopedFirstShotAccuracy;
        public float ScopedFirstShotAccuracy => scopedFirstShotAccuracy;
        
        [SerializeField] private float finalShotAccuracy;
        public float FinalShotAccuracy => finalShotAccuracy;
        
        [SerializeField] private float scopedFinalShotAccuracy;
        public float ScopedFinalShotAccuracy => scopedFinalShotAccuracy;

        [SerializeField] private float inaccuracyLerpPerShot;
        private float InaccuracyLerpPerShot => inaccuracyLerpPerShot;

        [Space(10)] 
        [SerializeField] private int magazineCapacity;
        private float MagazineCapacity => magazineCapacity;

        [SerializeField] private bool consumesAmmo;
        public bool ConsumesAmmo => consumesAmmo;

        [Space(10)]
        [SerializeField] private SelectiveFire firingMode;
        public SelectiveFire FiringMode => firingMode;

        [SerializeField] private int burstFire;
        public int BurstFire => burstFire;
        
        [Space(10)]
        
        [Space(10)]
        [SerializeField] private WeaponAction primaryFire;
        [SerializeField] private WeaponAction secondaryFire;
    }

    public enum SelectiveFire
    {
        SemiAutomatic,
        Automatic,
        Burst,
        SingleShot
    }
}
