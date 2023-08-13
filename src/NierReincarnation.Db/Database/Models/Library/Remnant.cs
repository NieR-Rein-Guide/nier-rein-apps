using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("remnant")]
public class Remnant : StoryItem
{
    [Key]
    public int Id { get; init; }

    public string Name { get; init; }

    public string Effect { get; init; }

    public string CategoryType { get; set; }

    public int Order { get; init; }
}
