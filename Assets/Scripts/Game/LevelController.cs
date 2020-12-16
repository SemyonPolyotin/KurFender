using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private CameraController _cameraController = default;
        [SerializeField] private List<Transform> _spawnPoints = default;
        [SerializeField] private GameObject _playerPrefab = default;

        private List<PlayerController> _players = new List<PlayerController>();

        private void Awake()
        {
            const int numPlayers = 2;

            for (var i = 0; i < numPlayers; i++)
            {
                CreatePlayer(i);
            }

            _cameraController.Initialize(_players.Select(controller => controller.transform).ToArray());
        }

        private void CreatePlayer(int i)
        {
            var playerGo = Instantiate(_playerPrefab);
            var playerController = playerGo.GetComponent<PlayerController>();
            playerController.transform.position = _spawnPoints[i].position;
            _players.Add(playerController);
        }
    }
}