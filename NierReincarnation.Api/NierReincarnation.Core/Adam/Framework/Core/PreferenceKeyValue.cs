namespace NierReincarnation.Core.Adam.Framework.Core;

public abstract class PreferenceKeyValue<T>
{
    private enum State
    {
        Unknown,
        Dirty,
        Normal
    }

    private State _state;

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

    protected T DefaultFallback { get; set; }

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
