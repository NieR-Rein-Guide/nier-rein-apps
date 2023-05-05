using System.ComponentModel.DataAnnotations;

namespace NierReincarnation.Db.Database.Models;

public class LostArchive : StoryItem
{
    [Key]
    public int Id { get; init; }

    public string Name { get; init; }

    public string Number { get; init; }
}
