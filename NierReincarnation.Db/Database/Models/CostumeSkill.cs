using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("costume_skill")]
internal class CostumeSkill
{
    public int SkillId { get; set; }

    public int SkillLevel { get; set; }

    public string GaugeRiseSpeed { get; set; }

    public int CooldownTime { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ShortDescription { get; set; }

    public string ImagePath { get; set; }

    public virtual ICollection<CostumeSkillLink> Costume { get; set; }
}
