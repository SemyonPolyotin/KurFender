using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent = default;
        
        private PlayerController _player;

        private void Awake()
        {
            _navMeshAgent.updateRotation = true;
        }

        private void Start()
        {
            _player = FindObjectOfType<PlayerController>();
        }

        private void Update()
        {
            _navMeshAgent.SetDestination(_player.transform.position);
        }
    }
}
