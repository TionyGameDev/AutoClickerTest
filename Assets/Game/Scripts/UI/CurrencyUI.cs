using Game.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class CurrencyUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI currencyText;
        [SerializeField]
        private TextMeshProUGUI _autoCollectText;
        
        public void Init()
        {
            CurrencyManager.Instance.onCurrencyChanged += UpdateCurrencyText;
            CurrencyManager.Instance.onCurrencyPerForSec += UpdateValuePerSecCurrencyText;
        }

        private void OnDisable()
        {
            CurrencyManager.Instance.onCurrencyChanged -= UpdateCurrencyText;
            CurrencyManager.Instance.onCurrencyPerForSec += UpdateValuePerSecCurrencyText;
        }

        private void UpdateCurrencyText(float currentCurrency)
        {
            if (currencyText)
             currencyText.text = $"Currency: {currentCurrency}";
        }
        private void UpdateValuePerSecCurrencyText(float valueForSec)
        {
            if (_autoCollectText)
                _autoCollectText.text = $"AutoForSec: {valueForSec}";
        }
    }
}