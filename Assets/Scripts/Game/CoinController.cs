using System;
using UnityEngine;

namespace Game
{
    public class CoinController : MonoBehaviour
    {
        private const float _rotationSpeed = 40f;

        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f);
            transform.position = _startPosition + new Vector3(0, transform.rotation.y * (float)Math.PI / 5, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<PlayerController>(out var playerController))
            {
                playerController.PlayerModel.CoinValue++;
                GameObject.Destroy(gameObject);
            }
        }
    }
}