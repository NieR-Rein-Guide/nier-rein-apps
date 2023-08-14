using NierReincarnation.Core.Adam.Framework.Core;

namespace NierReincarnation.Core.Dark.Preference;

public class PlayerPreference : PreferenceKeyStoreValue
{
    private const string kPlayerRegistrationsKey = "PlayerRegistrations";
    private const string kCurrentSystemLanguage = "CurrentSystemLanguage";
    private const int _defaultLanguage = 22;

    public static PlayerPreference Instance = new();

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
