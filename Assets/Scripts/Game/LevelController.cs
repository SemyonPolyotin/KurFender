using System;
using System.Collections.Generic;
using System.Linq;
using Game.Player;
using UnityEngine;

namespace Game
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private CameraController _cameraController = default;
        [SerializeField] private List<Transform> _spawnPoints = default;
        [SerializeField] private PlayerTypeDataBase _archerData = default;
        [SerializeField] private PlayerTypeDataBase _barbarianData = default;
        [SerializeField] private PlayerTypeDataBase _wizardData = default;

        private readonly List<PlayerController> _players = new List<PlayerController>();

        private void Awake()
        {
            //TODO: get list of players from PlayerSetupScreen
            var playerInfos = new List<PlayerInfo>
            {
                new PlayerInfo {PlayerType = _wizardData, Name = "Gandalf", Color = Color.red},
                new PlayerInfo {PlayerType = _archerData, Name = "Legolas", Color = Color.green},
                new PlayerInfo {PlayerType = _barbarianData, Name = "Gimli", Color = Color.blue}
            };

            Initialize(playerInfos);
        }

        private void Initialize(List<PlayerInfo> playerInfos)
        {
            for (var i = 0; i < playerInfos.Count; i++)
            {
                var playerInfo = playerInfos[i];
                CreatePlayer(i, playerInfo);
            }

            _cameraController.Initialize(_players.Select(controller => controller.transform).ToArray());

            var playerModels = _players.Select(playerController => playerController.PlayerModel).ToList();
            var gameView = GameObject.FindObjectOfType<GameView>();
            gameView.Initialize(playerModels);
        }

        private void CreatePlayer(int i, PlayerInfo playerInfo)
        {
            var playerGo = Instantiate(playerInfo.PlayerType.Prefab);
            var playerController = playerGo.GetComponent<PlayerController>();
            playerController.Initialize(playerInfo.Name, playerInfo.Color);
            IPlayerTypeStrategy strategy;
            switch (playerInfo.PlayerType)
            {
                case ArcherData archerData:
                    strategy = new ArcherStrategy(archerData);
                    break;
                case BarbarianData barbarianData:
                    strategy = new BarbarianStrategy(barbarianData);
                    break;
                case WizardData wizardData:
                    strategy = new WizardStrategy(wizardData);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            playerController.SetStrategy(strategy);
            playerController.transform.position = _spawnPoints[i].position;
            _players.Add(playerController);
        }
    }
}