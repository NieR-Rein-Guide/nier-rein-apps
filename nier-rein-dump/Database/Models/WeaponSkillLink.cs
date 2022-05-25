using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("weapon_skill_link")]
    class WeaponSkillLink
    {
        [Column("weapon_id")]
        public int WeaponId { get; set; }
        [Column("slot_number")]
        public int SlotNumber { get; set; }
        [Column("skill_id")]
        public int SkillId { get; set; }
        [Column("skill_level")]
        public int SkillLevel { get; set; }

        public Weapon Weapon { get; set; }
        public WeaponSkill WeaponSkill { get; set; }
    }
}
