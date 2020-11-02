using System;
using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody = default;
        [SerializeField] private float _jumpForce = 300f;
        [SerializeField] private float _jumpRaycastDistance = 0.1f;

        private Controls _controls;

        private void Awake()
        {
            _controls = new Controls();
            _controls.Player.Jump.started += context => Jump();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void Jump()
        {
            if (IsGrounded())
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce);
            }
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position + 0.1f * Vector3.up, -Vector3.up, _jumpRaycastDistance);
        }
    }
}