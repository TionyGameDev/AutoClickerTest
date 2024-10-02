using System;
using Game.Scripts.DataScriptable;
using Game.Scripts.Events;
using Game.Scripts.Managers;
using UnityEngine;
using EventHandler = Game.Scripts.Events.EventHandler;

namespace Game.Scripts.Clicker
{
    public class TapClicker : MonoBehaviour
    {
        private IClickSettings _clickSettings; 
        private CurrencyManager _currencyManager;
        private float _currentBonus = 0f;
        public event Action<Vector3, float> onClickPositionAndValue;
        public void Init(IClickSettings settings)
        {
            this._clickSettings = settings;

            _currencyManager = CurrencyManager.Instance;
            EventHandler.RegisterEvent<float>(EventName.StartBonus,SetAutoCollectBonus);
        }

        private void OnDisable()
        {
            EventHandler.UnregisterEvent<float>(EventName.StartBonus,SetAutoCollectBonus);
        }

        public void SetAutoCollectBonus(float bonus)
        {
            Debug.Log("Bonus " + bonus);
            _currentBonus = bonus;
        }

        public void OnClick(Vector3 positionClick)
        {
            if (_clickSettings != null)
            {
                float baseCurrency = _clickSettings.GetBaseCurrencyPerClick();
                float modifier = _clickSettings.GetClickModifier();
                float totalCurrency = baseCurrency * modifier + _currentBonus;

                _currencyManager.AddCurrency(totalCurrency); 
                onClickPositionAndValue?.Invoke(positionClick,totalCurrency);
                
                //Debug.Log($"Clicked! Added {totalCurrency} currency.");
            }
        }
        
    }
}