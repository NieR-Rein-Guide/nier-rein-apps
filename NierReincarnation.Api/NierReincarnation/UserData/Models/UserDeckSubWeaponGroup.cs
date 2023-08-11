using Newtonsoft.Json;
using System;

namespace NierReincarnation.UserData.Models;

public class UserDeckSubWeaponGroup
{
    [JsonProperty("userDeckCharacterUuid")]
    public Guid DeckCharacterUuid { get; set; }

    [JsonProperty("userWeaponUuid")]
    public Guid WeaponUuid { get; set; }

    [JsonProperty("sortOrder")]
    public int Slot { get; set; }
}
