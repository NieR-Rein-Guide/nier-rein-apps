using Newtonsoft.Json;
using System;

namespace NierReincarnation.UserData.Models;

public class UserDeckCharacter
{
    [JsonProperty("userDeckCharacterUuid")]
    public Guid DeckCharacterUuid { get; set; }

    [JsonProperty("userCostumeUuid")]
    public Guid? CostumeUuid { get; set; }

    [JsonProperty("mainUserWeaponUuid")]
    public Guid? MainWeaponUuid { get; set; }

    [JsonProperty("userCompanionUuid")]
    public Guid? CompanionUuid { get; set; }

    [JsonProperty("power")]
    public int Power { get; set; }
}
