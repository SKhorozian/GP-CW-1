using UnityEngine;

namespace SKhorozian.CoreGameplay.Weapons
{
    public abstract class WeaponAction : ScriptableObject
    {
        public abstract void DoAction(WeaponActionData data);
    }
}