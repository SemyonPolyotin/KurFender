using System;
using UnityEngine;

namespace Game
{
    public class PlayerModel
    {
        public string PlayerName { get; private set; }
        private const float _maxHpValue = 100f;
        private const float _maxSpValue = 50f;
        private const int _defaultCoinValue = 0;
        private float _hpValue;
        private float _spValue;
        private int _coinValue;
        public event Action OnHpValueChange;
        public event Action OnSpValueChange;
        public event Action OnCoinValueChange;
        
        private const float ImmuneTime = 1f;
        private float _immuneTimer = 0f;
        public bool IsImmune => _immuneTimer > 0f;

        public float HpValue
        {
            get => _hpValue;
            set
            {
                _hpValue = Mathf.Clamp(value, 0f, _maxHpValue);
                OnHpValueChange?.Invoke();
            }
        }
        
        public float SpValue
        {
            get => _spValue;
            set
            {
                _spValue = Mathf.Clamp(value, 0f, _maxSpValue);
                OnSpValueChange?.Invoke();
            }
        }

        public int CoinValue
        {
            get => _coinValue;
            set
            {
                _coinValue = value;
                OnCoinValueChange?.Invoke();
            }
        }

        public float MaxHpValue => _maxHpValue;
        public float MaxSpValue => _maxSpValue;
        
        public PlayerModel(string playerName)
        {
            PlayerName = playerName;
            //TODO make initialization stats update
            _hpValue = _maxHpValue;
            _spValue = _maxSpValue;
            _coinValue = _defaultCoinValue;
        }

        public void Tick(float deltaTime)
        {
            if (_immuneTimer > 0)
            {
                _immuneTimer -= deltaTime;
            }
        }
        
        public void ReceiveDamage(float damage)
        {
            if (!IsImmune)
            {
                if (SpValue > 0f)
                {
                    if (damage < SpValue)
                    {
                        SpValue -= damage;
                    }
                    else
                    {
                        HpValue -= (damage - SpValue);
                        SpValue = 0f;
                    }
                }
                else
                {
                    HpValue -= damage;
                }

                _immuneTimer = ImmuneTime;
            }
        }
    }
}