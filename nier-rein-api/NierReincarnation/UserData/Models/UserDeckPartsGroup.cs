using System;
using Newtonsoft.Json;

namespace NierReincarnation.UserData.Models
{
    public class UserDeckPartsGroup
    {
        [JsonProperty("userDeckCharacterUuid")]
        public Guid DeckCharacterUuid { get; set; }
        [JsonProperty("userPartsUuid")]
        public Guid PartsUuid { get; set; }
        [JsonProperty("sortOrder")]
        public int Slot { get; set; }
    }
}
