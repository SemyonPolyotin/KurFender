using Game.Enemies;
using UnityEngine;

namespace Game.Level
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
            if (other.GetComponent<ProjectileController>() != null)
            {
                return;
            }
            if (other.TryGetComponent<EnemyController>(out var enemyController))
            {
                GameObject.Destroy(enemyController.gameObject);
            }

            GameObject.Destroy(gameObject);
        }
    }
}