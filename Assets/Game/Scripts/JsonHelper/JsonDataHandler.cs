using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Scripts.JsonHelper
{
    public class JsonDataHandler<T> where T : new()
    {
        private string filePath;

        public JsonDataHandler(string fileName)
        {
            filePath = Path.Combine(Application.persistentDataPath, fileName);
        }

        public async Task SaveToFileAsync(T data)
        {
            string json = JsonUtility.ToJson(data, true); 
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                await writer.WriteAsync(json); 
            }
            
            Debug.Log("Data saved to " + filePath);
        }

        public async Task<T> LoadFromFileAsync()
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string json = await reader.ReadToEndAsync(); 
                    T data = JsonUtility.FromJson<T>(json); 
                    Debug.Log("Data loaded from " + filePath);
                    return data;
                }
            }
            else
            {
                Debug.Log("Save file not found");
                return new T(); 
            }
        }
    }
}