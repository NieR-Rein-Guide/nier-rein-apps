using System.Text.Json.Serialization;

namespace NierReincarnation.Db.Database.Models;

internal class CostumeKarmaItem
{
    [JsonPropertyName("rarity")]
    public string Rarity { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("image_path")]
    public string ImagePath { get; set; }
}
