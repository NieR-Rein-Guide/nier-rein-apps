using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("debris")]
internal class Thought
{
    [Key]
    [Column("debris_id")]
    public int ThoughtId { get; set; }

    public string Rarity { get; set; }

    public DateTimeOffset ReleaseTime { get; set; }

    public string Name { get; set; }

    public string DescriptionShort { get; set; }

    public string DescriptionLong { get; set; }

    public string ImagePathBase { get; set; }

    public virtual ICollection<Costume> Costumes { get; set; }

    public virtual ICollection<Character> Characters { get; set; }
}
