using System;
using Newtonsoft.Json;

namespace NierReincarnation.UserData.Models
{
    public class UserWeaponAbility
    {
        [JsonProperty("userWeaponUuid")]
        public Guid WeaponUuid { get; set; }
        [JsonProperty("slotNumber")]
        public int SlotNumber { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
    }
}
