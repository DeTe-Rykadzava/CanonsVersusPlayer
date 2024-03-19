using System.Collections;
using Input;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private readonly AInput _input = InputManager.Input;
        private readonly AMouseInput _mouseInput = InputManager.MouseInput;

        [Header("Specifications")]
        [SerializeField] private float speed = 5f;
        [SerializeField] private float sprintSpeed = 5f;
        [SerializeField] private float jumpHeight = 4f;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float maxAvailableJumps = 2f;
        [SerializeField] private float secondsForNewJump = 0.1f;
        

        [Header("Links")]
        [SerializeField] private CharacterController characterController;
        [SerializeField] public Transform cameraPoint;

        private Vector3 _cameraPointTransformVelocity;
        private Vector3 _velocity;
        private float _countAvailableJumps;
        private bool _isJumping = default; 

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _countAvailableJumps = maxAvailableJumps;
        }

        private void Update()
        {
            _input.Update();
            _mouseInput.Update();
        }

        private void FixedUpdate()
        {
            var source = transform;

            if (characterController.isGrounded && _velocity.y < 0)
                _velocity.y = -2f;
            if (characterController.isGrounded)
                _countAvailableJumps = maxAvailableJumps;
            
            var inputDirection = new Vector3(_input.LeftRight, 0, _input.ForwardBack).normalized;
            
            if (inputDirection.magnitude >= 0.1f)
            {
                float x;
                float z;

                if (characterController.isGrounded)
                {
                    x = inputDirection.x * (speed + sprintSpeed * _input.Sprint) * Time.fixedDeltaTime;
                    z = inputDirection.z * (speed + sprintSpeed * _input.Sprint) * Time.fixedDeltaTime;
                }
                else
                {
                    x = inputDirection.x * speed * Time.fixedDeltaTime;
                    z = inputDirection.z * speed * Time.fixedDeltaTime;
                }
                
                var move = source.forward * z + source.right * x;
                
                characterController.Move(move);
                
                source.rotation = Quaternion.Euler(0, cameraPoint.eulerAngles.y, 0);
            }

            if (_input.Jump && _countAvailableJumps != 0 && !_isJumping)
            {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                _countAvailableJumps -= 1;
                _isJumping = true;
                StartCoroutine(WaitForNewJump());
            }

            _velocity.y += gravity * Time.fixedDeltaTime;
            
            characterController.Move(_velocity * Time.fixedDeltaTime);
        }

        private IEnumerator WaitForNewJump()
        {
            yield return new WaitForSeconds(secondsForNewJump);
            _isJumping = false;
        }
    }
}