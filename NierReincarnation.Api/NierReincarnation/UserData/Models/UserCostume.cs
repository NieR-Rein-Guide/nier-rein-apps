using Newtonsoft.Json;
using System;

namespace NierReincarnation.UserData.Models;

public class UserCostume
{
    [JsonProperty("userCostumeUuid")]
    public Guid CustomeUuid { get; set; }

    [JsonProperty("costumeId")]
    public int CustomeId { get; set; }

    [JsonProperty("limitBreakCount")]
    public int LimitBreakCount { get; set; }

    [JsonProperty("level")]
    public int Level { get; set; }

    [JsonProperty("exp")]
    public int Experience { get; set; }
}
