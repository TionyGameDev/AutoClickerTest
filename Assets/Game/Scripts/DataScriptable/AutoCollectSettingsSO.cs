using System;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.DataScriptable
{
    [CreateAssetMenu(fileName = "AutoCollectSettings", menuName = "ScriptableObjects/AutoCollectSettings", order = 2)]
    public class AutoCollectSettingsSO : ScriptableObject 
    {
        [SerializeField]
        private float collectInterval = 5f;
        [SerializeField]
        private float amountPerInterval = 10f;
        [SerializeField]
        private float _bonusClick = 10f;
        [SerializeField]
        private float _valueBonusThreshold  = 100f;

        public float GetAmountPerInterval()
        {
            return amountPerInterval;
        }

        public float GetCollectInterval()
        {
            return collectInterval;
        }

        public float GetPerForSecValue()
        {
            return amountPerInterval / collectInterval;
        }

        public void Init()
        {
            GlobalValue.bonusClick = _bonusClick;
            GlobalValue.valueBonusThreshold = _valueBonusThreshold;  
        }
    }
}