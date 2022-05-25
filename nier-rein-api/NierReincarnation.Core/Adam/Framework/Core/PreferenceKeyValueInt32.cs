using System;

namespace NierReincarnation.Core.Adam.Framework.Core
{
    // Adam.Framework.Core.PreferenceKeyValueInt32
    class PreferenceKeyValueInt32 : PreferenceKeyValue<int>
    {
        public PreferenceKeyValueInt32(string key, PreferenceKeyStoreValue keyStoreValue, int defaultFallback = 0) :
            base(key, keyStoreValue, defaultFallback)
        {
        }

        protected override int GetValue()
        {
            if (!int.TryParse(KeyStoreValue.GetString(Key), out var res))
                return DefaultFallback;

            return res;
        }

        protected override void Save()
        {
            if (KeyStoreValue == null)
                throw new ArgumentNullException(nameof(KeyStoreValue));

            KeyStoreValue.SetString(Key, InternalValue.ToString());
        }

        protected override bool CheckDirty(int value)
        {
            return InternalValue != value;
        }

        protected override void CheckDirtyForGet()
        {
            return;
        }
    }
}
