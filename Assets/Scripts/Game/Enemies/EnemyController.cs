using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent = default;

        private void Awake()
        {
            _navMeshAgent.updateRotation = true;
        }

        private void OnCollisionStay(Collision other)
        {
            var playerController = other.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                const float damage = 20f;
                playerController.PlayerModel.ReceiveDamage(damage);
            }
        }
    }
}
