using System;
using System.Threading.Tasks;
using Game.Scripts.DataScriptable;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Clicker
{
    public class AutoCollectClicker : MonoBehaviour
    {
        private AutoCollectSettingsSO _autoCollectSettings;
        private CurrencyManager _currencyManager;
        private float _collectInterval;
        private bool _active;
        
        public void Init(AutoCollectSettingsSO settings)
        {
            _autoCollectSettings = settings;
            _currencyManager = CurrencyManager.Instance;
            _collectInterval = settings.GetCollectInterval();

            _active = true;
            StartAutoCollect();

            _currencyManager.valuePerForSec = _autoCollectSettings.GetPerForSecValue();
            
            //Debug.Log("AutoCollector initialized with new settings.");
        }

        private async void StartAutoCollect()
        {
            while (_active)
            {
                await Task.Delay((int)(_collectInterval * 1000));

                var collectedAmount = _autoCollectSettings.GetAmountPerInterval();
                _currencyManager.AddCurrencyAuto(collectedAmount);

                //Debug.Log($"Auto-collect: Added {collectedAmount} currency.");
            }
        }

        private void OnDisable()
        {
            _active = false;
        }
    }
}