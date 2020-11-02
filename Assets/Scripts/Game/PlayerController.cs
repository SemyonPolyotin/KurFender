using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody = default;
        [SerializeField] private float _jumpForce = 300f;
        [SerializeField] private float _jumpRaycastDistance = 0.1f;

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

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }
}