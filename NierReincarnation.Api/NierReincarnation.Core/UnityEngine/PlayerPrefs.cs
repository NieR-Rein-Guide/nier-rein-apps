using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Xml;

namespace NierReincarnation.Core.UnityEngine
{
    /// <summary>
    /// Class reimplementing shared player preferences structure, as specified here: https://docs.unity3d.com/ScriptReference/PlayerPrefs.html
    /// </summary>
    class PlayerPrefs
    {
        private readonly string _filePath;
        private readonly IDictionary<string, (string, object)> _items;

        private static string PlayerPrefsPath => Path.Combine(Application.SharedPrefsPath, Application.Identifier + ".v2.playerprefs.xml");

        private static readonly Lazy<PlayerPrefs> Lazy = new Lazy<PlayerPrefs>(() => new PlayerPrefs(PlayerPrefsPath));
        public static PlayerPrefs Instance => Lazy.Value;

        // CUSTOM: Tells if the preference file exists
        public static bool Exists => File.Exists(PlayerPrefsPath);

        public PlayerPrefs(string filePath)
        {
            _filePath = filePath;
            _items = new Dictionary<string, (string, object)>();

            if (!File.Exists(filePath))
                return;

            var xml = new XmlDocument();
            xml.Load(filePath);

            if (xml["map"] == null)
                return;

            foreach (XmlElement element in xml["map"].ChildNodes)
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

        public void DeleteAll()
        {
            _items.Clear();
        }

        public void DeleteKey(string key)
        {
            _items.Remove(key);
        }

        public float GetFloat(string key)
        {
            return 0;
        }

        public int GetInt(string key)
        {
            if (!_items.ContainsKey(key))
                return 0;

            return (int)_items[key].Item2;
        }

        public string GetString(string key)
        {
            if (!_items.ContainsKey(key))
                return null;

            return HttpUtility.UrlDecode((string)_items[key].Item2);
        }

        public bool HasKey(string key)
        {
            return _items.ContainsKey(key);
        }

        public void Save()
        {
            // Create file
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
            using var mapFile = File.Create(_filePath);

            // Create XmlDocument
            var xmlDoc = new XmlDocument();

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

        public void SetFloat(string key, float value)
        {
            ;
        }

        public void SetInt(string key, int value)
        {
            _items[key] = ("int", value.ToString());
        }

        public void SetString(string key, string value)
        {
            _items[key] = ("string", HttpUtility.UrlEncode(value));
        }
    }
}
