using System;
using UnityEngine;

namespace Game
{
    public class ProjectileController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody = default;

        public void Initialize(Vector3 position, Vector3 direction, float speed)
        {
            transform.position = position;
            _rigidbody.AddForce(direction * speed, ForceMode.VelocityChange);
        }

        private void OnTriggerEnter(Collider other)
        {
            GameObject.Destroy(gameObject);
        }
    }
}