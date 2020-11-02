using System;
using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody = default;
        [SerializeField] private float _jumpForce = 300f;
        [SerializeField] private float _jumpRaycastDistance = 0.1f;
        [SerializeField] private float _movementSpeed = 1.0f;
        
        private Controls _controls;
        
        private Vector2 _movementDirection;
        private Vector2 _rotationDirection;

        private void Awake()
        {
            _controls = new Controls();
            _controls.Player.Jump.started += context => Jump();
            _controls.Player.Move.performed += context => _movementDirection = context.ReadValue<Vector2>();
            _controls.Player.Move.canceled += context => _movementDirection = Vector2.zero;
            _controls.Player.Rotate.performed += context => _rotationDirection = context.ReadValue<Vector2>();
            _controls.Player.Rotate.canceled += context => _rotationDirection = Vector2.zero;
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void FixedUpdate()
        {
            var offset = _movementDirection * (_movementSpeed * Time.deltaTime);
            transform.position += new Vector3(offset.x, 0.0f, offset.y);
            transform.LookAt(transform.position + new Vector3(_rotationDirection.x, 0.0f, _rotationDirection.y));
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position + 0.1f * Vector3.up, -Vector3.up, _jumpRaycastDistance);
        }

        private void Jump()
        {
            if (IsGrounded())
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce);
            }
        }
    }
}