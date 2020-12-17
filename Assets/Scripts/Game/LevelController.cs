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
            var playerInfos = new List<PlayerInfo>
            {
                new PlayerInfo {Name = "Gandalf", Color = Color.red},
                new PlayerInfo {Name = "Legolas", Color = Color.green}
            };

            Initialize(playerInfos);
        }

        private void Initialize(List<PlayerInfo> playerInfos)
        {
            for (var i = 0; i < playerInfos.Count; i++)
            {
                var playerInfo = playerInfos[i];
                CreatePlayer(i, playerInfo.Name, playerInfo.Color);
            }

            _cameraController.Initialize(_players.Select(controller => controller.transform).ToArray());

            var playerModels = _players.Select(playerController => playerController.PlayerModel).ToList();
            var gameView = GameObject.FindObjectOfType<GameView>();
            gameView.Initialize(playerModels);
        }

        private void CreatePlayer(int i, string playerName, Color color)
        {
            var playerGo = Instantiate(_playerPrefab);
            var playerController = playerGo.GetComponent<PlayerController>();
            playerController.Initialize(playerName, color);
            playerController.transform.position = _spawnPoints[i].position;
            _players.Add(playerController);
        }
    }
}