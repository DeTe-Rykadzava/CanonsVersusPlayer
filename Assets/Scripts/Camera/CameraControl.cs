using JetBrains.Annotations;
using UnityEngine;

namespace Camera
{
    public class CameraControl : MonoBehaviour
    {
        [SerializeField] [CanBeNull] public Transform cameraPoint;

        private Vector3 _smoothDampVelocity;
    
        private void LateUpdate()
        {
            if(cameraPoint == null) return;        
            var source = transform;
            source.position = cameraPoint.position;
            source.rotation = cameraPoint.rotation;
        }
    }
}