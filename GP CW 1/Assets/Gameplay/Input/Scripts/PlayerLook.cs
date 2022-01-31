using UnityEngine;

namespace SKhorozian.FPSController.Input
{
    public class PlayerLook : MonoBehaviour
    {
        //References
        [SerializeField] private Transform orientation;
        [SerializeField] private Transform cameraHolder;

        //Values
        [Space (10)]
        [SerializeField] private float sensitivity = 100f;
        
        void Start()
        {
            InputManager.Instance.OnLookInput.AddListener(Look);
        }

        private float _xRotation;
        void Look(Vector2 input)
        {
            var xAxis = Vector3.up * input.x * sensitivity;

            _xRotation -= input.y * sensitivity;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
            
            orientation.Rotate(eulers: xAxis);
            cameraHolder.localRotation = Quaternion.Euler(_xRotation, orientation.rotation.eulerAngles.y, 0f);

        }
    
    }
}