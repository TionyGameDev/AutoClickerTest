using UnityEngine;

namespace Game.Scripts.JsonHelper
{
    [System.Serializable]
    public class SaveData
    {
        public float currency;
        public float autoCollectBonusAllTime;
        public float lastCollectTime;

        public SaveData()
        {
            currency = 0f;
            autoCollectBonusAllTime = 0f;
            lastCollectTime = 0f;
        }
    }

}