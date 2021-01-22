using Game.Player;
using TMPro;
using UI;
using UnityEngine;

namespace Game.UI
{
    public class PlayerInfoWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playerNameText = default;
        [SerializeField] private ProgressBarHorizontal _hpBar = default;
        [SerializeField] private ProgressBarHorizontal _spBar = default;
        [SerializeField] private TextMeshProUGUI _coinCount = default;

        private PlayerModel _playerModel;

        public void Initialize(PlayerModel playerModel)
        {
            _playerModel = playerModel;
            _playerNameText.text = playerModel.PlayerName;
            _playerModel.OnHpValueChange += OnHpValueChange;
            _playerModel.OnSpValueChange += OnSpValueChange;
            _playerModel.OnCoinValueChange += OnCoinValueChange;
        }

        private void OnHpValueChange()
        {
            _hpBar.SetProgress(_playerModel.HpValue / _playerModel.MaxHpValue);
        }

        private void OnSpValueChange()
        {
            _spBar.SetProgress(_playerModel.SpValue / _playerModel.MaxSpValue);
        }

        private void OnCoinValueChange()
        {
            _coinCount.SetText($"Coins: {_playerModel.CoinValue}");
        }
    }
}