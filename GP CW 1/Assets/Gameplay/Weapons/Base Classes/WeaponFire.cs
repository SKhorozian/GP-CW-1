using UnityEngine;

namespace SKhorozian.CoreGameplay.Weapons
{
    public abstract class WeaponFire : ScriptableObject
    {
        public abstract void DoAction(WeaponActionData data);
    }
}