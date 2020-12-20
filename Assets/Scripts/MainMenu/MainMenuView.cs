using Core;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _startButton = default;
        [SerializeField] private Button _exitButton = default;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonClick);
            _exitButton.onClick.AddListener(OnExitButtonClick);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClick);
            _exitButton.onClick.RemoveListener(OnExitButtonClick);
        }

        private void OnStartButtonClick()
        {
            ModuleManager.LoadGame("DemoScene");
        }

        private void OnExitButtonClick()
        {
            Application.Quit();
        }
    }
}