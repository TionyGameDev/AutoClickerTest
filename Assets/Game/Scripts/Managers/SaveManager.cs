using System.Threading.Tasks;
using Game.Scripts.JsonHelper;
using Game.Scripts.Singleton;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class SaveManager : Singleton<SaveManager>
    {
        private JsonDataHandler<SaveData> jsonDataHandler;

        protected override void Awake()
        {
            base.Awake();
            jsonDataHandler = new JsonDataHandler<SaveData>("saveData.json");
        }

        public async Task SaveGameAsync(SaveData data)
        {
            await jsonDataHandler.SaveToFileAsync(data);
        }
    
        public async Task<SaveData> LoadGameAsync()
        {
            return await jsonDataHandler.LoadFromFileAsync();
        }
    
        private void OnApplicationQuit()
        {
            var currManager = CurrencyManager.Instance; 
            var save = new SaveData();
            save.currency = currManager.GetCurrency();
            save.autoCollectBonusAllTime = currManager.autoBonusAllTime;
            SaveGameAsync(save).Wait();
        }
    }
}