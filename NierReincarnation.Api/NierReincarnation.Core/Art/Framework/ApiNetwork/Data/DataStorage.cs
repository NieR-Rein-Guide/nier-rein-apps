using Newtonsoft.Json;
using NierReincarnation.Core.UnityEngine;
using System.IO;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Data
{
    // Art.Framework.ApiNetwork.Data.DataStorage
    // Note: BinaryFormatter is obsolete and was replaced with JsonSerializer
    internal class DataStorage : IDataStorage
    {
        private string _path; // 0x10
        private string _fileName; // 0x18

        public DataStorage(string fileName = "")
        {
            // CUSTOM: Base directory based on Unity reimplementation
            _path = Path.Combine(Application.PersistentDataPath, "files", "adrata", "ud");
            _fileName = string.IsNullOrEmpty(fileName) ? ".data.bin" : fileName;
        }

        public string GetFilePath() => Path.Combine(_path, _fileName);

        public T Load<T>(string filePath) where T : new()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
            }
            catch
            {
                return new T();
            }
        }

        public bool Save<T>(string filePath, T value)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(value));

            return true;
        }
    }
}
