using UnityEngine;

namespace SKhorozian.GPCW.UI
{
    public class FaceCameraUI : MonoBehaviour
    {
        private void LateUpdate() {
            if (Camera.main == null) return;
            
            var worldPos = transform.position + Camera.main.transform.rotation * Vector3.forward;
            var worldUp = Camera.main.transform.rotation * Vector3.up;
            
            transform.LookAt(worldPos, worldUp);
        }
    }
}