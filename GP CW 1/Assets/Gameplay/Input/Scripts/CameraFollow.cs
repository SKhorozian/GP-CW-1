using Unity.Mathematics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;
    
    private void Update() {
        transform.position = cameraPos.position;
    }
}
