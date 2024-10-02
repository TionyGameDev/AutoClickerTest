using System;
using Game.Scripts.Clicker;
using Game.Scripts.DataScriptable;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Managers
{ 
    public class InitManager : MonoBehaviour
    {
        [SerializeField] 
        private TapClicker _tapClicker;
        [SerializeField] 
        private AutoCollectClicker _autoCollect;
        [SerializeField] 
        private BaseGameUI _baseGameUI;
        
        [SerializeReference]
        public StandardClickSettingsSO clickSettings; 
        [SerializeReference]
        public AutoCollectSettingsSO autoCollectorSettings;
        
        private void Start()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            autoCollectorSettings.Init();
            if (_baseGameUI)
                _baseGameUI.Init(_autoCollect,_tapClicker);
            
            if (_tapClicker != null)
                _tapClicker.Init(clickSettings);

            if (_autoCollect)
                _autoCollect.Init(autoCollectorSettings);

           

            Debug.Log("Components initialized!");
        }
    }

}