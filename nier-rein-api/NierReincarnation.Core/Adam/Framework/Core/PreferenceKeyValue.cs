using System;

namespace NierReincarnation.Core.Adam.Framework.Core
{
    abstract class PreferenceKeyValue<T>
    {
        enum State
        {
            Unknown,
            Dirty,
            Normal
        }

        // Fields
        private State _state; // 0x30

        // Properties
        public T Value
        {
            get
            {
                CheckDirtyForGet();

                if (_state != State.Normal)
                {
                    if (KeyStoreValue == null)
                        throw new ArgumentNullException(nameof(KeyStoreValue));

                    if (KeyStoreValue.HasKey(Key))
                    {
                        InternalValue = GetValue();
                        _state = State.Normal;
                    }
                }

                return InternalValue;
            }
            set
            {
                if (CheckDirty(value))
                {
                    InternalValue = value;
                    Save();

                    _state = State.Normal;
                }
            }
        }

        // 0x10
        protected string Key { get; set; }
        // 0x18
        protected T InternalValue { get; set; }
        // 0x?? depends on T
        protected T DefaultFallback { get; set; }
        // 0x?? depends on T
        protected PreferenceKeyStoreValue KeyStoreValue { get; set; }

        protected PreferenceKeyValue(string key, PreferenceKeyStoreValue keyStoreValue, T defaultFallback)
        {
            Key = key;
            KeyStoreValue = keyStoreValue;
            DefaultFallback = defaultFallback;
            InternalValue = defaultFallback;
        }

        public void DeleteKey()
        {
            if (KeyStoreValue == null)
                throw new ArgumentNullException(nameof(KeyStoreValue));

            KeyStoreValue.DeleteKey(Key);
        }

        // 0x178
        protected abstract T GetValue();

        // 0x188
        protected abstract void Save();

        // 0x198
        protected abstract bool CheckDirty(T value);

        // 0x1A8
        protected abstract void CheckDirtyForGet();

        // 0x1B8
        protected void SetDirty()
        {
            _state = State.Dirty;
        }
    }
}
