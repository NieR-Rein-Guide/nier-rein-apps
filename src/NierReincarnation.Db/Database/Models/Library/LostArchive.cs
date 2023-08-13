using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("lost_archive")]
public class LostArchive : StoryItem
{
    [Key]
    public int Id { get; init; }

    public string Name { get; init; }

    public string Number { get; init; }

    public int Order { get; init; }
}
