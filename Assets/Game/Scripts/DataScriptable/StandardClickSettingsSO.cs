using UnityEngine;

namespace Game.Scripts.DataScriptable
{
    [CreateAssetMenu(fileName = "ClickSettings", menuName = "ScriptableObjects/ClickSettings", order = 1)]
    public class StandardClickSettingsSO  : ScriptableObject, IClickSettings
    {
        [SerializeField]
        private  float baseSoftCurrencyPerClick = 10f;
        [SerializeField]
        private  float clickModifier = 1f; 
        [SerializeField]
        private  float incomeSum; 
        [SerializeField]
        private  float divisor;
        public float GetBaseCurrencyPerClick()
        {
            return baseSoftCurrencyPerClick;
        }

        public float GetClickModifier()
        {
            return clickModifier;
        }
    }
}
