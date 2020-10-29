using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private Button _pauseButton = default;
    [SerializeField] private GameObject _pauseDialog = default;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(onPauseButtonClick);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(onPauseButtonClick);
    }

    private void onPauseButtonClick()
    {
        _pauseDialog.SetActive(true);
    }
}