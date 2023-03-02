using Newtonsoft.Json;
using NierReincarnation.Core.Dark.Generated.Type;
using System;

namespace NierReincarnation.UserData.Models
{
    public class UserDeck
    {
        [JsonProperty("deckType")]
        public DeckType DeckType { get; set; }

        [JsonProperty("userDeckNumber")]
        public int DeckNumber { get; set; }

        [JsonProperty("userDeckCharacterUuid01")]
        public Guid? DeckCharacterUuid01 { get; set; }

        [JsonProperty("userDeckCharacterUuid02")]
        public Guid? DeckCharacterUuid02 { get; set; }

        [JsonProperty("userDeckCharacterUuid03")]
        public Guid? DeckCharacterUuid03 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("power")]
        public int Power { get; set; }
    }
}
