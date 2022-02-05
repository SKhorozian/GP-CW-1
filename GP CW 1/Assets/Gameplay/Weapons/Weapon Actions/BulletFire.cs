using SKhorozian.FPSController.Character;
using UnityEngine;

namespace SKhorozian.CoreGameplay.Weapons
{
    public class BulletFire : WeaponFire
    {
        [SerializeField] protected LayerMask hurtboxLayer;

        public override void DoAction(WeaponActionData data) {
            var ray = new Ray {
                origin = data.FirePoint,
                direction = data.Direction
            };
            
            RaycastHit hit;
            
            if (!Physics.Raycast(ray, out hit, 500f, hurtboxLayer)) return;

            
        }
    }

    public struct ShotResult
    {
        public CharacterEntity hit;
        public Vector3 hitPoint;

    }
}