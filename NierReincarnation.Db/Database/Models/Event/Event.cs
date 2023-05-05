using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

public class Event
{
    [Key]
    public int Id { get; init; }

    public string Name { get; init; }

    public string ImagePath { get; init; }

    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset EndDate { get; set; }

    [Column(TypeName = "jsonb")]
    public StoryItem[] Stories { get; init; }
}
