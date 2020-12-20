using System;
using UnityEngine;

namespace Game
{
    public class TriggerZone : MonoBehaviour
    {
        public event Action<PlayerController> OnTriggerZoneEnter;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<PlayerController>(out var playerController))
            {
                OnTriggerZoneEnter?.Invoke(playerController);
            }
        }
    }
}
