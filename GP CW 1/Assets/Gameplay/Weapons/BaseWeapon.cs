using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : ScriptableObject
{
    [SerializeField] private WeaponAction primaryFire;
    [SerializeField] private WeaponAction secondaryFire;
}
