using NierReincarnation.Core.Dark.Preference;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Adam.Framework.Core;

public class PreferenceKeyStoreValue
{
    private const string kPrivateKeyPrefix = "dead";
    private const string kPrivateKeyRandom = "nan";
    private const string kPrivateKeySuffix = "x";
    private const string kRandomKey = "deadnanx";

    private string _privateKey;

    public bool IsInitialized { get; set; }

    public bool EnabledLoggingErrors { get; set; }

    public void Initialize()
    {
        if (IsInitialized) return;

        if (!HasKey(kRandomKey))
        {
            GeneratePrivateKey();
        }
        else
        {
            ReadPrivateKey();
        }

        IsInitialized = true;
    }

    public void SetString(string key, string value)
    {
        PlayerPrefs.Instance.SetString(key, DES.Encryption(value, _privateKey));
    }

    public string GetString(string key)
    {
        return GetString(key, string.Empty);
    }

    public string GetString(string key, string fallbackValue)
    {
        var value = PlayerPrefs.Instance.GetString(key);
        return !string.IsNullOrEmpty(value) ? DES.Decryption(value, _privateKey) : fallbackValue;
    }

    public void SetInt32(string key, int val)
    {
        SetString(key, val.ToString());
    }

    public int GetInt32(string key)
    {
        var value = GetString(key);
        int.TryParse(value, out var result);

        return result;
    }

    public int GetInt32(string key, int fallbackValue)
    {
        var value = GetString(key);

        return int.TryParse(value, out int result) ? result : fallbackValue;
    }

    public long GetInt64(string key)
    {
        var value = GetString(key);
        long.TryParse(value, out var result);

        return result;
    }

    public long GetInt64(string key, long fallbackValue)
    {
        var value = GetString(key);

        return long.TryParse(value, out long result) ? result : fallbackValue;
    }

    public void SetInt64(string key, long val)
    {
        SetString(key, val.ToString());
    }

    public bool GetBool(string key)
    {
        var value = GetString(key);
        return int.TryParse(value, out int result) && result == 1;
    }

    public bool GetBool(string key, bool fallbackValue)
    {
        var value = GetString(key);
        return (int.TryParse(value, out int result) && result == 1) || fallbackValue;
    }

    public void SetBool(string key, bool val)
    {
        SetString(key, val.ToString());
    }

    public float GetFloat(string key)
    {
        var value = GetString(key);
        float.TryParse(value, out var result);

        return result;
    }

    public float GetFloat(string key, float fallbackValue)
    {
        var value = GetString(key);

        return float.TryParse(value, out float result) ? result : fallbackValue;
    }

    public void SetFloat(string key, float val)
    {
        SetString(key, val.ToString());
    }

    public void SetValue<T>(string key, T genericObject)
    {
        SetString(key, JsonConvert.SerializeObject(genericObject));
    }

    public bool GetValue<T>(string key, out T genericObject, T defaultFallback)
    {
        var value = GetString(key);
        if (string.IsNullOrEmpty(value))
        {
            genericObject = defaultFallback;
            return false;
        }

        genericObject = typeof(T).Name switch
        {
            nameof(PlayerRegistrationMap) => (T)(object)JsonConvert.DeserializeObject<PlayerRegistrationMap>(value),
            _ => (T)Convert.ChangeType(value, typeof(T))
        };
        return true;
    }

    public void DeleteKey(string key) => PlayerPrefs.Instance.DeleteKey(key);

    public void DeleteAll() => PlayerPrefs.Instance.DeleteAll();

    public bool HasKey(string key) => PlayerPrefs.Instance.HasKey(key);

    private void ReadPrivateKey()
    {
        _privateKey = kPrivateKeyPrefix + kPrivateKeyRandom + kPrivateKeySuffix;
        _privateKey = kPrivateKeyPrefix + GetString(kRandomKey) + kPrivateKeySuffix;
    }

    private void GeneratePrivateKey()
    {
        Random random = new();
        int randomBase = random.Next(100, 1000);

        _privateKey = kPrivateKeyPrefix + kPrivateKeyRandom + kPrivateKeySuffix;
        SetString(kRandomKey, randomBase.ToString());

        _privateKey = $"{kPrivateKeyPrefix}{randomBase}{kPrivateKeySuffix}";
    }
}
