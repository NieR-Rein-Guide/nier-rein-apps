using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NierReincarnation.Core.Dark.Preference;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Adam.Framework.Core
{
    // Adam.Framework.Core.PreferenceKeyStoreValue
    class PreferenceKeyStoreValue
    {
        private static readonly string kPrivateKeyPrefix = "dead"; // 0x0
        private static readonly string kPrivateKeyRandom = "nan"; // 0x8
        private static readonly string kPrivateKeySuffix = "x"; // 0x10
        private static readonly string kRandomKey = "deadnanx"; // 0x18

        private string _privateKey; // 0x18
        private DES _des; // 0x20

        // 0x10
        public bool IsInitialized { get; set; }
        // 0x11
        public bool EnabledLoggingErrors { get; set; }

        // Done
        public PreferenceKeyStoreValue()
        {
            _des = new DES();
        }

        // Done
        public void Initialize()
        {
            if (IsInitialized)
                return;

            if (!HasKey(kRandomKey))
                GeneratePrivateKey();
            else
                ReadPrivateKey();

            IsInitialized = true;
        }

        // Done
        public void SetString(string key, string value)
        {
            PlayerPrefs.Instance.SetString(key, _des.Encryption(value, _privateKey));
        }

        // Done
        public string GetString(string key)
        {
            return GetString(key, string.Empty);
        }

        // Done
        public string GetString(string key, string fallbackValue)
        {
            var value = PlayerPrefs.Instance.GetString(key);
            if (string.IsNullOrEmpty(value))
                return fallbackValue;

            return _des.Decryption(value, _privateKey);
        }

        // Done
        public void SetInt32(string key, int val)
        {
            SetString(key, val.ToString());
        }

        // Done
        public int GetInt32(string key)
        {
            var value = GetString(key);

            int.TryParse(value, out var result);

            return result;
        }

        // Done
        public int GetInt32(string key, int fallbackValue)
        {
            var value = GetString(key);

            if (!int.TryParse(value, out var result))
                result = fallbackValue;

            return result;
        }

        // Done
        public long GetInt64(string key)
        {
            var value = GetString(key);

            long.TryParse(value, out var result);

            return result;
        }

        // Done
        public long GetInt64(string key, long fallbackValue)
        {
            var value = GetString(key);

            if (!long.TryParse(value, out var result))
                result = fallbackValue;

            return result;
        }

        // Done
        public void SetInt64(string key, long val)
        {
            SetString(key, val.ToString());
        }

        // Done
        public bool GetBool(string key)
        {
            var value = GetString(key);

            return int.TryParse(value, out var result) && result == 1;
        }

        // Done
        public bool GetBool(string key, bool fallbackValue)
        {
            var value = GetString(key);

            return int.TryParse(value, out var result) && result == 1 || fallbackValue;
        }

        // Done
        public void SetBool(string key, bool val)
        {
            SetString(key, val.ToString());
        }

        // Done
        public float GetFloat(string key)
        {
            var value = GetString(key);

            float.TryParse(value, out var result);

            return result;
        }

        // Done
        public float GetFloat(string key, float fallbackValue)
        {
            var value = GetString(key);

            if (!float.TryParse(value, out var result))
                result = fallbackValue;

            return result;
        }

        // Done
        public void SetFloat(string key, float val)
        {
            SetString(key, val.ToString());
        }

        // Done
        public void SetValue<T>(string key, T genericObject)
        {
            SetString(key, JsonConvert.SerializeObject(genericObject));
        }

        // Done
        public bool GetValue<T>(string key, out T genericObject, T defaultFallback)
        {
            var value = GetString(key);
            if (string.IsNullOrEmpty(value))
            {
                genericObject = defaultFallback;
                return false;
            }

            // Differences in NewtonsoftJson and Unity Json library need work-around
            // HINT: Explicit type checks as work-around
            switch (typeof(T).Name)
            {
                case nameof(PlayerRegistrationMap):
                    genericObject = (T)(object)JsonConvert.DeserializeObject<PlayerRegistrationMap>(value);
                    break;

                default:
                    genericObject = (T)Convert.ChangeType(value, typeof(T));
                    break;
            }

            return true;
        }

        // Done
        public void DeleteKey(string key)
        {
            PlayerPrefs.Instance.DeleteKey(key);
        }

        // Done
        public void DeleteAll()
        {
            PlayerPrefs.Instance.DeleteAll();
        }

        // Done
        public bool HasKey(string key)
        {
            return PlayerPrefs.Instance.HasKey(key);
        }

        // Done
        private void ReadPrivateKey()
        {
            _privateKey = $"{kPrivateKeyPrefix}{kPrivateKeyRandom}{kPrivateKeySuffix}";
            _privateKey = $"{kPrivateKeyPrefix}{GetString(kRandomKey)}{kPrivateKeySuffix}";
        }

        // Done
        private void GeneratePrivateKey()
        {
            var random = new Random();
            var randomBase = random.Next(100, 1000);

            _privateKey = $"{kPrivateKeyPrefix}{kPrivateKeyRandom}{kPrivateKeySuffix}";
            SetString(kRandomKey, randomBase.ToString());

            _privateKey = $"{kPrivateKeyPrefix}{randomBase}{kPrivateKeySuffix}";
        }
    }
}
