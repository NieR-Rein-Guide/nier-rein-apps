using System.Web;
using System.Xml;

namespace NierReincarnation.Core.UnityEngine;

/// <summary>
/// Class reimplementing shared player preferences structure, as specified here: https://docs.unity3d.com/ScriptReference/PlayerPrefs.html
/// </summary>
public class PlayerPrefs
{
    private readonly string _filePath;
    private readonly Dictionary<string, (string, object)> _items;

    private static string PlayerPrefsPath => Path.Combine(Application.SharedPrefsPath, Application.Identifier + ".v2.playerprefs.xml");

    private static readonly Lazy<PlayerPrefs> Lazy = new(() => new PlayerPrefs(PlayerPrefsPath));

    public static PlayerPrefs Instance => Lazy.Value;

    public static bool Exists => File.Exists(PlayerPrefsPath);

    public PlayerPrefs(string filePath)
    {
        _filePath = filePath;
        _items = new Dictionary<string, (string, object)>();

        if (!File.Exists(filePath)) return;

        XmlDocument xml = new();
        xml.Load(filePath);

        if (xml["map"] == null) return;

        foreach (XmlElement element in xml["map"]!.ChildNodes)
        {
            var type = element.Name;
            var name = element.Attributes["name"]?.Value;
            var value = element.FirstChild?.Value;

            if (value == null)
                continue;

            object parsedValue;
            switch (type)
            {
                case "int":
                    parsedValue = int.Parse(value);
                    break;

                case "string":
                    parsedValue = value;
                    break;

                default:
                    continue;
            }

            _items[name] = (type, parsedValue);
        }
    }

    public void SetInt(string key, int value) => _items[key] = ("int", value.ToString());

    public int GetInt(string key) => _items.TryGetValue(key, out (string, object) value) ? (int)value.Item2 : 0;

    public void SetString(string key, string value) => _items[key] = ("string", HttpUtility.UrlEncode(value));

    public string GetString(string key) => _items.TryGetValue(key, out (string, object) value) ? HttpUtility.UrlDecode((string)value.Item2) : null;

    public bool HasKey(string key) => _items.ContainsKey(key);

    public void DeleteKey(string key) => _items.Remove(key);

    public void DeleteAll() => _items.Clear();

    public void Save()
    {
        // Create file
        Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
        using FileStream mapFile = File.Create(_filePath);

        // Create XmlDocument
        XmlDocument xmlDoc = new();

        // Write values
        var mapElement = xmlDoc.CreateElement("map");
        xmlDoc.AppendChild(mapElement);

        foreach (var item in _items)
        {
            var itemElement = xmlDoc.CreateElement(item.Value.Item1);
            itemElement.SetAttribute("name", item.Key);
            itemElement.InnerText = item.Value.Item2?.ToString() ?? string.Empty;

            mapElement.AppendChild(itemElement);
        }

        // Save document to file
        xmlDoc.Save(mapFile);
    }
}
