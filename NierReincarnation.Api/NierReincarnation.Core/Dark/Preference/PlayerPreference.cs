using NierReincarnation.Core.Adam.Framework.Core;

namespace NierReincarnation.Core.Dark.Preference;

// Dark.Preference.PlayerPreference
class PlayerPreference : PreferenceKeyStoreValue
{
    private static readonly string kPlayerRegistrationsKey = "PlayerRegistrations";
    private static readonly string kCurrentSystemLanguage = "CurrentSystemLanguage";
    private static readonly int _defaultLanguage = 22;

    public static PlayerPreference Instance = new PlayerPreference();

    private PreferenceKeyValueInt32 _currentLanguage;
    private PlayerRegistrationMap _playerRegistrations;
    private PlayerRegistration _activePlayer;

    public PlayerRegistrationMap PlayerRegistrations
    {
        get
        {
            if (!GetValue<PlayerRegistrationMap>(kPlayerRegistrationsKey, out var value, null))
                value = _playerRegistrations;

            _playerRegistrations = value;
            return value;
        }
        set
        {
            _playerRegistrations = value;

            SetValue(kPlayerRegistrationsKey, value);
        }
    }

    public int CurrentLanguage { get => _currentLanguage.Value; set => _currentLanguage.Value = value; }

    public PlayerRegistration ActivePlayer
    {
        get
        {
            if (TryGetActivePlayer(out var player))
                return player;

            return null;
        }
        set
        {
            _activePlayer = value;

            _playerRegistrations[value.ServerAddressAndPort] = value;
            PlayerRegistrations = _playerRegistrations;
        }
    }

    public PlayerPreference()
    {
        _playerRegistrations = new PlayerRegistrationMap();

        GeneratePreferenceParameter();
    }

    private void GeneratePreferenceParameter()
    {
        _currentLanguage = new PreferenceKeyValueInt32(kCurrentSystemLanguage, this, _defaultLanguage);
    }

    private bool TryGetActivePlayer(out PlayerRegistration player)
    {
        if (_activePlayer != null)
        {
            player = _activePlayer;
            return player != null;
        }

        var activeKey = PlayerRegistrationMap.GenerateActiveKey();
        Instance.PlayerRegistrations.TryGetValue(activeKey, out _activePlayer);

        player = _activePlayer;
        return player != null;
    }
}
