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
        private State _state;

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

       
        protected string Key { get; set; }
       
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

       
        protected abstract T GetValue();

       
        protected abstract void Save();

       
        protected abstract bool CheckDirty(T value);

       
        protected abstract void CheckDirtyForGet();

       
        protected void SetDirty()
        {
            _state = State.Dirty;
        }
    }
}
