using Newtonsoft.Json;

namespace NierReincarnation.UserData.Models;

public class UserWeapon
{
    [JsonProperty("userWeaponUuid")]
    public Guid WeaponUuid { get; set; }

    [JsonProperty("weaponId")]
    public int WeaponId { get; set; }

    [JsonProperty("level")]
    public int Level { get; set; }

    [JsonProperty("exp")]
    public int Experience { get; set; }

    [JsonProperty("limitBreakCount")]
    public int LimitBreakCount { get; set; }

    [JsonProperty("isProtected")]
    public bool IsProtected { get; set; }
}
