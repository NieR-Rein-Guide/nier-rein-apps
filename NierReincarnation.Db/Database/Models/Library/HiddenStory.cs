using System.Text.Json.Serialization;

namespace NierReincarnation.Db.Database.Models;

public class HiddenStoryItem : StoryItem
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("number")]
    public string Number { get; init; }
}
