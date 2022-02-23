using System.Net.Http.Headers;
using UnityEngine;

namespace SKhorozian.GPCW.Input
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        
        [Space(10)]
        [SerializeField] private Vector3 offset;
        [SerializeField] private float maxDistanceFromPlayer;
        
        [SerializeField] private float lerpAmount;
        private Vector3 _velocity = Vector3.zero;
        
        void Start() {
            playerTransform = GameObject.FindWithTag("Player").transform;
        }

        void FixedUpdate() {
            var playerPos = playerTransform.position;

            var mouseScreenPos = InputProvider.instance.MouseScreenPosition;
            mouseScreenPos /= new Vector2(Screen.width, Screen.height);
            mouseScreenPos = (mouseScreenPos - (Vector2.one/2)) * 2;

            var mouseWorldPos = new Vector3(mouseScreenPos.x * maxDistanceFromPlayer + playerPos.x, 0, mouseScreenPos.y * maxDistanceFromPlayer + playerPos.z);
            var midpoint = new Vector3((playerPos.x + mouseWorldPos.x) / 2, playerPos.y, (playerPos.z + mouseWorldPos.z) / 2);

            var lookPos = midpoint + offset;

            transform.position = Vector3.SmoothDamp(transform.position, lookPos, ref _velocity, lerpAmount);
        }
    }
}