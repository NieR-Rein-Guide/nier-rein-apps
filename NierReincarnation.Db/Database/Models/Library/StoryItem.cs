using System.Text.Json.Serialization;

namespace NierReincarnation.Db.Database.Models;

public class StoryItem
{
    [JsonPropertyName("story")]
    public string Story { get; init; }

    [JsonPropertyName("image_path")]
    public string ImagePath { get; init; }
}
