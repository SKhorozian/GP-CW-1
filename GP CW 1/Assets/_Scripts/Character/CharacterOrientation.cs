using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace SKhorozian.GPCW.Character
{
    public class CharacterOrientation : MonoBehaviour
    {
        [SerializeField] private GameObject orientation;

        public void SetRotation(Vector2 input) {
            input.Normalize();

            var lookRot = new Vector3(input.x, 0, input.y);
            
            orientation.transform.rotation = Quaternion.LookRotation(lookRot);
        }

    }
}