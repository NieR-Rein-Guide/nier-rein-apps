using Newtonsoft.Json;

namespace NierReincarnation.UserData.Models;

public class UserPart
{
    [JsonProperty("userPartsUuid")]
    public Guid PartsUuid { get; set; }

    [JsonProperty("partsId")]
    public int PartsId { get; set; }

    [JsonProperty("level")]
    public int Level { get; set; }

    [JsonProperty("partsStatusMainId")]
    public int StatusMainId { get; set; }

    [JsonProperty("isProtected")]
    public bool IsProtected { get; set; }
}
