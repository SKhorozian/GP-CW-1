using System;
using UnityEngine;

namespace SKhorozian.FPSController.Input
{
    public class PlayerLook : MonoBehaviour
    {
        //References
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Transform camTransform;
        
        //Values
        [Space (10)]
        [SerializeField] private float sensitivity = 100f;
        
        void Start()
        {
            InputManager.Instance.OnLookInput.AddListener(Look);
        }

        float xRotation = 0f;
        void Look(Vector2 input)
        {
            Vector3 xAxis = playerTransform.up * input.x * sensitivity;

            xRotation -= input.y * sensitivity;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            
            camTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerTransform.Rotate(xAxis);
        }
    
    }
}