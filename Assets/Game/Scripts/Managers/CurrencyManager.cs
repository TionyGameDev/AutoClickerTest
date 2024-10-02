using System;
using System.Threading.Tasks;
using Game.Scripts.Events;
using Game.Scripts.JsonHelper;
using Game.Scripts.Singleton;
using UnityEngine;
using EventHandler = Game.Scripts.Events.EventHandler;

namespace Game.Scripts.Managers
{
    public class CurrencyManager : Singleton<CurrencyManager>
    {
        private float _currencyAmount;
        private float _valuePerForSec;
        private float _autoBonusAllTime;
        public float autoBonusAllTime => _autoBonusAllTime;
        
        private SaveManager saveLoadManager;
        public event Action<float> onCurrencyChanged;
        public event Action<float> onCurrencyPerForSec;

        public float valuePerForSec
        {
            set
            {
                SetValuePerSec(value);
                onCurrencyPerForSec?.Invoke(value);
            }
            get { return _valuePerForSec; }
        }

        private void SetValuePerSec(float value)
        {
            _valuePerForSec = value;
        }

        private async void Start()
        {
            saveLoadManager = SaveManager.Instance;
            await LoadCurrency(); 
        }

        public void AddCurrency(float amount)
        {
            _currencyAmount += amount;
            onCurrencyChanged?.Invoke(_currencyAmount);
            //Debug.Log($"Currency added: {amount}. Total currency: {currencyAmount}");
        }
        public void AddCurrencyAuto(float amount)
        {
            _currencyAmount += amount;
            onCurrencyChanged?.Invoke(_currencyAmount);
            
            _autoBonusAllTime += amount;
            if (_autoBonusAllTime >= GlobalValue.valueBonusThreshold)
                EventHandler.ExecuteEvent<float>(EventName.StartBonus,_autoBonusAllTime / GlobalValue.bonusClick);
            
            //Debug.Log($"Currency added: {amount}. Total currency: {currencyAmount}");
        }

        public float GetCurrency()
        {
            return _currencyAmount;
        }

        private async Task LoadCurrency()
        {
            SaveData saveData = await saveLoadManager.LoadGameAsync();
            if (saveData != null)
            {
                _autoBonusAllTime = saveData.autoCollectBonusAllTime;
                AddCurrency(saveData.currency);
                AddCurrencyAuto(0);
            }
            
        }

       
    }
}