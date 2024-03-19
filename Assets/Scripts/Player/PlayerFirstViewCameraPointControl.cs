using System;
using Input;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerFirstViewCameraPointControl : MonoBehaviour
    {
        private readonly AMouseInput _mouseInput = InputManager.MouseInput;
        
        [SerializeField] private Vector3 currentRotation;
        
        [Header("Camera point")]
        [SerializeField] private float mouseSensitivity = 50f;
        [SerializeField] private Vector3 pointOffset;
        
        [Header("Links")]
        [SerializeField] public Transform cameraPoint;
        [SerializeField] private Transform player;

        private void Awake()
        {
            cameraPoint.rotation = player.rotation;
        }


        private void FixedUpdate()
        {
            cameraPoint.position = player.position + pointOffset;
        }

        private void LateUpdate()
        {
            var mouseX = _mouseInput.MouseX * mouseSensitivity * Time.fixedDeltaTime;
            var mouseY = _mouseInput.MouseY * mouseSensitivity * Time.fixedDeltaTime;

            currentRotation.y += mouseX;
            currentRotation.x -= mouseY;
            
            var rotation = Quaternion.Euler(currentRotation);
            cameraPoint.rotation = rotation;
        }
    }
}