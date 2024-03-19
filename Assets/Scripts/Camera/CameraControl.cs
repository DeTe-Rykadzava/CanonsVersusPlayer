using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] public Transform cameraPoint;
    [SerializeField] private float smoothTimeToCameraPoint = 0.1f;

    private Vector3 _smoothDampVelocity;
    
    private void LateUpdate()
    {
        if(cameraPoint == null) return;        
        var source = transform;
        source.position = cameraPoint.position;
        source.rotation = cameraPoint.rotation;
    }
}