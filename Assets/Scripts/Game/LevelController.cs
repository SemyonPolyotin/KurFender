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

        private readonly List<PlayerController> _players = new List<PlayerController>();

        private void Awake()
        {
            //TODO: get list of players from PlayerSetupScreen
            const int numPlayers = 1;

            for (var i = 0; i < numPlayers; i++)
            {
                CreatePlayer(i);
            }

            _cameraController.Initialize(_players.Select(controller => controller.transform).ToArray());

            var playerModels = _players.Select(playerController => playerController.PlayerModel).ToList();
            var gameView = GameObject.FindObjectOfType<GameView>();
            gameView.Initialize(playerModels);
        }

        private void CreatePlayer(int i)
        {
            var playerGo = Instantiate(_playerPrefab);
            var playerController = playerGo.GetComponent<PlayerController>();
            playerController.Initialize($"Player: {i}");
            playerController.transform.position = _spawnPoints[i].position;
            _players.Add(playerController);
        }
    }
}