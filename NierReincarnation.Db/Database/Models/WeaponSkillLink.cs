using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("weapon_skill_link")]
internal class WeaponSkillLink
{
    public int WeaponId { get; set; }

    public int SlotNumber { get; set; }

    public int SkillId { get; set; }

    public int SkillLevel { get; set; }

    [ForeignKey(nameof(WeaponId))]
    public Weapon Weapon { get; set; }

    public WeaponSkill WeaponSkill { get; set; }
}
