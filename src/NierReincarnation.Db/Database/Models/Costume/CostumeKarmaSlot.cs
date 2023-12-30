using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("costume_karma_slot")]
internal class CostumeKarmaSlot
{
    public int CostumeId { get; set; }

    public int Order { get; set; }

    public DateTimeOffset ReleaseTime { get; set; }

    [ForeignKey(nameof(CostumeId))]
    public virtual Costume Costume { get; set; }

    [Column(TypeName = "jsonb")]
    public CostumeKarmaItem[] KarmaItems { get; set; }
}
