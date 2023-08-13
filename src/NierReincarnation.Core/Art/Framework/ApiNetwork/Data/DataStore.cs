namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Data;

public class DataStore : IDataStore, IDisposable
{
    private Dictionary<Key, string> _cache;
    private readonly IDataStorage _dataStorage;

    public static DataStore Default { get; } = new DataStore(string.Empty);

    public DataStore(string fileName = "")
    {
        _dataStorage = new DataStorage(fileName);

        var directoryName = Path.GetDirectoryName(_dataStorage.GetFilePath());
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }

        Load();
    }

    public void Dispose() => _cache = null;

    public string Get(Key key) => _cache.TryGetValue(key, out var value) ? value : string.Empty;

    public long GetLong(Key key)
    {
        long.TryParse(Default.Get(key), out var result);
        return result;
    }

    public void Set(Key key, string value)
    {
        _cache[key] = value;
        Save();
    }

    public void Set(Key key, long value) => Set(key, value.ToString());

    private void Load() => _cache = _dataStorage.Load<Dictionary<Key, string>>(_dataStorage.GetFilePath());

    private void Save() => _dataStorage.Save(_dataStorage.GetFilePath(), _cache);
}
