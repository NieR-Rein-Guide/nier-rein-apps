using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Data
{
    // Note: BinaryFormatter is obsolete and was replaced with JsonSerializer
    public class DataStorage : IDataStorage
    {
        private readonly string _path;
        private readonly string _fileName;

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
