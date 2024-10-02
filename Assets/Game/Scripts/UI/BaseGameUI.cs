using System;
using Game.Scripts.Clicker;
using Game.Scripts.Singleton;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class BaseGameUI : Singleton<BaseGameUI>
    {
        [SerializeField] private ClickButtonUI _clickButtonUI;
        [SerializeField] private CurrencyUI _currencyUI;
        [SerializeField] private FloatingTextUI _floatingTextUI;
        [SerializeField] private GameObject _main;


        public void Init(AutoCollectClicker autoCollectClicker,TapClicker tapClicker)
        {
            if (_main)
                _main.gameObject.SetActive(true);
            
            if (_currencyUI)
                _currencyUI.Init();
            
            if (_clickButtonUI)
                _clickButtonUI.Init(tapClicker);
            
            if (_floatingTextUI)
                _floatingTextUI.Init(tapClicker);
        }
    }
}