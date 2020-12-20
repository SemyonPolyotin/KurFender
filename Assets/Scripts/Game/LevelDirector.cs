using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class LevelDirector
    {
        private readonly List<PlayerModel> _playerModels;
        private GameView _gameView;

        public LevelDirector(List<PlayerModel> playerModelsList, List<TriggerZone> winTriggerList)
        {
            _gameView = GameObject.FindObjectOfType<GameView>();

            _playerModels = playerModelsList;
            foreach (var playerModel in _playerModels)
            {
                playerModel.OnHpValueChange += PlayerModelOnOnHpValueChange;
            }

            foreach (var winTrigger in winTriggerList)
            {
                winTrigger.OnTriggerZoneEnter += OnTriggerZoneEnter;
            }
        }

        private void PlayerModelOnOnHpValueChange()
        {
            if (_playerModels.All(model => model.IsDead))
            {
                _gameView.ShowEndGameDialog(false);
            }
        }

        private void OnTriggerZoneEnter(PlayerController playerController)
        {
            _gameView.ShowEndGameDialog(true);
        }
    }
}