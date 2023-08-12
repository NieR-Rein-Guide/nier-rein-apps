using Newtonsoft.Json.Linq;

namespace NierReincarnation.Core.Dark.Preference;

// Dark.Preference.PlayerRegistrationMap
[JsonConverter(typeof(MapJsonConverter))]
internal class PlayerRegistrationMap
{
    private Dictionary<string, PlayerRegistration> _playerRegistrations;

    public PlayerRegistration this[string index]
    {
        get => _playerRegistrations[index];
        set => _playerRegistrations[index] = value;
    }

    public PlayerRegistrationMap()
    {
        _playerRegistrations = new Dictionary<string, PlayerRegistration>();
    }

    public static string GenerateActiveKey()
    {
        var serverAddress = KernelState.NetworkConfig.ServerAddress;
        var port = KernelState.NetworkConfig.ServerPort;

        return GenerateKey(serverAddress, port);
    }

    public static string GenerateKey(string serverAddress, int serverPort)
    {
        return $"{serverAddress}{serverPort}";
    }

    public bool TryGetValue(string key, out PlayerRegistration player)
    {
        return _playerRegistrations.TryGetValue(key, out player);
    }

    private class MapJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(PlayerRegistrationMap);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var map = (PlayerRegistrationMap)value;
            if (map == null)
                return;

            serializer.Serialize(writer, new
            {
                _keys = map._playerRegistrations.Keys.ToArray(),
                _values = map._playerRegistrations.Values.ToArray()
            });
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var mapObj = (JObject)serializer.Deserialize(reader);

            var keys = mapObj["_keys"].ToArray();
            var values = mapObj["_values"].ToArray();

            var result = new PlayerRegistrationMap();
            for (var i = 0; i < keys.Length; i++)
                result[keys[i].Value<string>()] = values[i].ToObject<PlayerRegistration>();

            return result;
        }
    }
}
