using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NierReincarnation.Db.Database.Models;

[Table("hidden_story")]
public class HiddenStoryItem : StoryItem
{
    public string Name { get; init; }

    public string Number { get; init; }
}
