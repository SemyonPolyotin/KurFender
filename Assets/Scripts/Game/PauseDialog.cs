using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class PauseDialog : MonoBehaviour
    {
        [SerializeField] private Button _returnToMainMenuButton = default;
        [SerializeField] private Button _continueButton = default;
        [SerializeField] private GameObject _pauseDialog = default;

        private void OnEnable()
        {
            _continueButton.onClick.AddListener(OnContinueButtonClick);
            _returnToMainMenuButton.onClick.AddListener(OnReturnToMainMenuButtonClick);
        }

        private void OnDisable()
        {
            _continueButton.onClick.RemoveListener(OnContinueButtonClick);
            _returnToMainMenuButton.onClick.RemoveListener(OnReturnToMainMenuButtonClick);
        }

        private void OnContinueButtonClick()
        {
            _pauseDialog.SetActive(false);
        }

        private void OnReturnToMainMenuButtonClick()
        {
            ModuleManager.LoadMainMenu();
        }
    
    }
}