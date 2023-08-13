using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("costume")]
internal class Costume
{
    [Key]
    public int CostumeId { get; set; }

    public int CharacterId { get; set; }

    public string AssetId { get; set; }

    public int? EmblemId { get; set; }

    [Column("debris_id")]
    public int? ThoughtId { get; set; }

    public string Attribute { get; set; }

    public string WeaponType { get; set; }

    public string Rarity { get; set; }

    public DateTimeOffset ReleaseTime { get; set; }

    public bool IsExCostume { get; set; }

    public bool IsRdCostume { get; set; }

    [Column("slug")]
    public string CostumeSlug { get; set; }

    [Column("title")]
    public string Name { get; set; }

    public string Description { get; set; }

    public string ImagePathBase { get; set; }

    [ForeignKey(nameof(CharacterId))]
    public virtual Character Character { get; set; }

    [ForeignKey(nameof(EmblemId))]
    public virtual Emblem Emblem { get; set; }

    [ForeignKey(nameof(ThoughtId))]
    public virtual Thought Thought { get; set; }

    public virtual ICollection<CostumeSkillLink> Skills { get; set; }

    public virtual ICollection<CostumeAbilityLink> Abilities { get; set; }

    public virtual ICollection<CostumeStat> Stats { get; set; }
}
