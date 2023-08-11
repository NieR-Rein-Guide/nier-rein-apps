using Newtonsoft.Json;
using System;

namespace NierReincarnation.UserData.Models;

public class UserCompanion
{
    [JsonProperty("userCompanionUuid")]
    public Guid CompanionUuid { get; set; }

    [JsonProperty("companionId")]
    public int CompanionId { get; set; }

    [JsonProperty("level")]
    public int Level { get; set; }
}
