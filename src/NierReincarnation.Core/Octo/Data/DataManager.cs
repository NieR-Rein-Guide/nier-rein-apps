using NierReincarnation.Core.Octo.Proto;
using NierReincarnation.Core.Octo.Util;
using ProtoBuf;

namespace NierReincarnation.Core.Octo.Data;

public class DataManager : IDatabase
{
    private const string Tag = "Octo/DataManager";
    public static readonly string DirName = "pdb";
    private const string CacheFileName = "octocacheevai";

    private readonly string _dataPath;
    private readonly AESCrypt _aes;
    private string[] _tags;
    private Dictionary<string, Item> _assetBundleDictionary;
    private Dictionary<string, Item> _resourceDictionary;
    private readonly int _version;
    private string _urlFormat;
    private string AssetBundleUrlFormat;
    private string ResourceUrlFormat;

    public int Revision { get; set; }

    internal DataManager(int appId, int version, AESCrypt crypt)
    {
        _version = version;

        var root = FileUtil.GetDatabaseRoot();
        var args = new string[4];
        args[0] = DirName;
        args[1] = appId.ToString();
        args[2] = version.ToString();
        args[3] = CacheFileName;

        _dataPath = FileUtil.UnsafePathCombine(root, args);
        _aes = crypt;
    }

    public void Initialize()
    {
        ConstructDictionaryWithLocalDatabase();
    }

    public Error ApplyToDatabase(byte[] downloadedBytes, bool reset)
    {
        Database db = StaticSerializer.Deserialize<Database>(downloadedBytes);
        if (db == null)
        {
            return new Error("octo.network.unknown_reason", "Failed to deserialize database");
        }

        SetUrls(db);

        if (db.Revision == Revision && !reset)
        {
            return null;
        }

        _tags = db.TagName.ToArray();
        SecureFile file = new(_dataPath, _aes);
        if (Revision == 0 || !reset)
        {
            Revision = db.Revision;
            ConstructDictionary(db);

            return file.Save(downloadedBytes);
        }

        Revision = db.Revision;
        foreach (var ab in db.AssetBundleList)
        {
            UpdateWithNewData(_assetBundleDictionary, ab);
        }

        foreach (var resource in db.ResourceList)
        {
            UpdateWithNewData(_resourceDictionary, resource);
        }

        ResetAllDependencies(db);

        return file.Save(SerializeDatabase());
    }

    public Item GetAssetBundleItemByName(string name, bool allowDeleted = false)
    {
        return GetItemByName(_assetBundleDictionary, OctoUtil.FastToLower(name), false);
    }

    public Item GetResourceItemByName(string name, bool allowDeleted = false)
    {
        return GetItemByName(_resourceDictionary, name, allowDeleted);
    }

    public HashSet<Item> GetAssetBundleItemsByTag(IList<string> tags)
    {
        return GetItems(_assetBundleDictionary, item => ContainsTag(tags, item));
    }

    public HashSet<Item> GetResourceItemsByTag(IList<string> tags)
    {
        return GetItems(_resourceDictionary, item => ContainsTag(tags, item));
    }

    public string[] GetAllAssetBundleNames()
    {
        var items = GetItems(_assetBundleDictionary, item => item.state != Proto.Data.DataState.Delete);
        return items.Select(i => i.name).ToArray();
    }

    public string[] GetAllResourceNames()
    {
        var items = GetItems(_resourceDictionary, item => item.state != Proto.Data.DataState.Delete);
        return items.Select(i => i.name).ToArray();
    }

    public string GenerateAssetBundleUrl(Item item)
    {
        return AssetBundleUrlFormat
            .Replace("{o}", item.objectName.ToString())
            .Replace("{g}", item.generation.ToString())
            .Replace("{v}", item.uploadVersionId.ToString());
    }

    public string GenerateResourceUrl(Item item)
    {
        return ResourceUrlFormat
            .Replace("{o}", item.objectName.ToString())
            .Replace("{g}", item.generation.ToString())
            .Replace("{v}", item.uploadVersionId.ToString());
    }

    public void DeleteData()
    {
        FileUtil.FileDelete(_dataPath);
        Reset();
    }

    private void ConstructDictionaryWithLocalDatabase()
    {
        var db = ReadSecureDatabase();
        if (db.Data == null)
        {
            Reset();
            return;
        }

        SetUrls(db.Data);
        ConstructDictionary(db.Data);
    }

    private SecureProtoBufDatabase<Database> ReadSecureDatabase()
    {
        var db = new SecureProtoBufDatabase<Database>(_dataPath, _aes);
        db.Deserialize();

        return db;
    }

    private void Reset()
    {
        Revision = 0;
        _tags = null;

        _assetBundleDictionary = new Dictionary<string, Item>();
        _resourceDictionary = new Dictionary<string, Item>();

        _urlFormat = null;
        AssetBundleUrlFormat = null;
        ResourceUrlFormat = null;
    }

    private void SetUrls(Database db)
    {
        if (_urlFormat == db.UrlFormat)
            return;

        _urlFormat = db.UrlFormat;
        AssetBundleUrlFormat = db.UrlFormat.Replace("{type}", "assetbundle");
        ResourceUrlFormat = db.UrlFormat.Replace("{type}", "resources");
    }

    private void ConstructDictionary(Database db)
    {
        var items = db.AssetBundleList.ConvertAll(ab => ItemFactory.Create(ab, db.TagName));
        _assetBundleDictionary = new Dictionary<string, Item>(items.Count + 1000);

        foreach (var item in items)
            _assetBundleDictionary[item.name] = item;

        ResetAllDependencies(db);

        var items2 = db.ResourceList.ConvertAll(r => ItemFactory.CreateByResource(r, db.TagName));
        _resourceDictionary = new Dictionary<string, Item>(db.ResourceList.Count + 1000);

        foreach (var data in items2)
            _resourceDictionary[data.name] = data;
    }

    private void ResetAllDependencies(Database db)
    {
        var deps = new Dictionary<int, Item>(_assetBundleDictionary.Count);
        foreach (var value in _assetBundleDictionary.Values)
            deps[value.id] = value;

        foreach (var ab in db.AssetBundleList)
            _assetBundleDictionary[ab.Name].SetDependencies(ab, deps);
    }

    private void UpdateWithNewData(Dictionary<string, Item> dictionary, Proto.Data octoData)
    {
        if (!dictionary.TryGetValue(octoData.Name, out var value))
        {
            dictionary[octoData.Name] = ItemFactory.Create(octoData, _tags);
            return;
        }

        if (ItemFactory.IsSameItemType(value, octoData))
            value.SetData(octoData, _tags);
        else
            dictionary[octoData.Name] = ItemFactory.Create(octoData, _tags);
    }

    private byte[] SerializeDatabase()
    {
        var tagIds = new Dictionary<string, int>(_tags.Length);
        for (var i = 0; i < _tags.Length; i++)
            tagIds[_tags[i]] = i;

        // Note: To accommodate no direct access to ProtoWriter, we create and statically serialize the Database object here
        Database db = new()
        {
            Revision = Revision,
            AssetBundleList = _assetBundleDictionary.Values.Select(x => x.GetData(tagIds)).ToList(),
            TagName = _tags.ToList(),
            ResourceList = _resourceDictionary.Values.Select(x => x.GetData(tagIds)).ToList(),
            UrlFormat = _urlFormat
        };

        MemoryStream ms = new();
        Serializer.Serialize(ms, db);

        return ms.ToArray();
    }

    private static Item GetItemByName(Dictionary<string, Item> dictionary, string name, bool allowDeleted)
    {
        if (!allowDeleted)
        {
            dictionary.TryGetValue(name, out var value);
            return value;
        }

        dictionary.TryGetValue(name, out var value1);
        if (OctoManager.AllowDeleted && value1 != null && !value1.IsValid)
        {
            // Log error with OctoManager+0x18 with message (Tag, ('Trying to use item with deleted flag (maybe dependencies): {0}', name))
        }

        return value1;
    }

    private bool ContainsTag(IList<string> tags, Item item)
    {
        // CUSTOM (Probably): The method searches for any tag from 'tags' in 'item.Tags'
        foreach (var tag in tags)
        {
            if (item.Tags.Contains(tag))
                return true;
        }

        return false;
    }

    private static HashSet<Item> GetItems(Dictionary<string, Item> dictionary, Func<Item, bool> predicate)
    {
        var result = new HashSet<Item>();
        foreach (var value in dictionary.Values)
        {
            if (predicate?.Invoke(value) ?? false)
                result.Add(value);
        }

        return result;
    }
}
