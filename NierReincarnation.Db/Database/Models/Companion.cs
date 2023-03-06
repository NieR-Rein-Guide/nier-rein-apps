using NierReincarnation.Core.Dark.Generated.Type;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("companion")]
internal class Companion
{
    [Key]
    public int CompanionId { get; set; }

    public string Attribute { get; set; }

    public int Type { get; set; }

    public DateTimeOffset ReleaseTime { get; set; }

    public string Name { get; set; }

    public string Story { get; set; }

    public string ImagePathBase { get; set; }

    public virtual ICollection<CompanionSkillLink> Skill { get; set; }

    public virtual ICollection<CompanionAbilityLink> Ability { get; set; }

    public virtual ICollection<CompanionStat> Stats { get; set; }
}
