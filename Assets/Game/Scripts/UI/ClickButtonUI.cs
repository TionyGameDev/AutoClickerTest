using System;
using Game.Scripts.Clicker;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class ClickButtonUI : MonoBehaviour
    {
        [SerializeField]
        private Button clickButton; 

        private TapClicker _clicker;
        
        public void Init(TapClicker clicker)
        {
            _clicker = clicker;
            clickButton.onClick.AddListener(OnClick);
        }
        private void OnClick()
        {
            Vector3 clickPosition = Input.mousePosition;
            Vector3 diference = Camera.main.ScreenToWorldPoint(clickPosition) * 100;
            diference.z = 0;
            
            if (_clicker != null)
                _clicker.OnClick(diference);
        }
    }
}