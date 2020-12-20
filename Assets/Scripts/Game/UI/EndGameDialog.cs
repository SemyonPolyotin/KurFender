using System;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI
{
    public class EndGameDialog : MonoBehaviour
    {
        [SerializeField] private GameObject _victoryContainer = default;
        [SerializeField] private GameObject _defeatContainer = default;
        [SerializeField] private Button _toMainMenuButton = default;
        [SerializeField] private Button _restartLevelButton = default;

        public void Initialize(bool isVictory)
        {
            _victoryContainer.SetActive(isVictory);
            _defeatContainer.SetActive(!isVictory);
        }

        private void OnEnable()
        {
            _toMainMenuButton.onClick.AddListener(OnToMainMenuButtonClick);
            _restartLevelButton.onClick.AddListener(OnRestartLevelButtonClick);
        }

        private void OnDisable()
        {
            _toMainMenuButton.onClick.RemoveListener(OnToMainMenuButtonClick);
            _restartLevelButton.onClick.RemoveListener(OnRestartLevelButtonClick);
        }

        private void OnToMainMenuButtonClick()
        {
            ModuleManager.LoadMainMenu();
        }

        private void OnRestartLevelButtonClick()
        {
            ModuleManager.LoadGame(SceneManager.GetActiveScene().path);
        }
    }
}