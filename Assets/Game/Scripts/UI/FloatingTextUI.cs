using System;
using System.Collections;
using Game.Scripts.Clicker;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class FloatingTextUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI floatingTextPrefab;
        [SerializeField]
        private Transform canvasTransform;

        private TapClicker _tapClicker;
        public void Init(TapClicker tapClicker)
        {
            _tapClicker = tapClicker;
            _tapClicker.onClickPositionAndValue += ShowFloatingText;
        }

        private void OnDisable()
        {
            _tapClicker.onClickPositionAndValue -= ShowFloatingText;
        }

        public void ShowFloatingText(Vector3 position, float amount)
        {
            var floatingText = Instantiate(floatingTextPrefab, canvasTransform);
            floatingText.transform.SetParent(transform);
            floatingText.text = "+" + amount;

            StartCoroutine(AnimateFloatingText(floatingText.GetComponent<RectTransform>(),position));
        }
        
        private IEnumerator AnimateFloatingText(RectTransform floatingTextObject,Vector3 pos)
        {
            float duration = 1f; 
            Vector3 startPosition = pos;
            Vector3 endPosition = startPosition + new Vector3(0, 100f, 0);

            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                floatingTextObject.localPosition = Vector3.Lerp(startPosition, endPosition, (elapsedTime / duration));
                elapsedTime += Time.deltaTime;
                yield return null; 
            }

            Destroy(floatingTextObject.gameObject);
        }
    }
}