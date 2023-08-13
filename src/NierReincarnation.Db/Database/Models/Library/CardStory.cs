using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("card_story")]
public class CardStory
{
    [Key]
    public int Id { get; init; }

    public string Name { get; init; }

    [Column(TypeName = "jsonb")]
    public StoryItem[] Stories { get; init; }
}
