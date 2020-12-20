using System.Collections.Generic;
using Game.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private GameObject _playerInfoWidgetPrefab = default;
        [SerializeField] private Transform _playerInfoWidgetContainer = default;
        [SerializeField] private Button _pauseButton = default;
        [SerializeField] private GameObject _pauseDialog = default;
        [SerializeField] private EndGameDialog _endGameDialog = default;

        public void Initialize(List<PlayerModel> playerModels)
        {
            foreach (var playerModel in playerModels)
            {
                var playerInfoWidgetGO = GameObject.Instantiate(_playerInfoWidgetPrefab, _playerInfoWidgetContainer);
                var playerInfoWidget = playerInfoWidgetGO.GetComponent<PlayerInfoWidget>();
                playerInfoWidget.Initialize(playerModel);
            }
        }

        public void ShowEndGameDialog(bool isVictory)
        {
            _endGameDialog.gameObject.SetActive(true);
            _endGameDialog.Initialize(isVictory);
        }
        
        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(OnPauseButtonClick);
        }

        private void OnDisable()
        {
            _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        }

        private void OnPauseButtonClick()
        {
            _pauseDialog.SetActive(true);
        }
    }
}