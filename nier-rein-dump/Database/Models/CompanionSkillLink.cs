using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("companion_skill_link")]
    class CompanionSkillLink
    {
        [Column("companion_id")]
        public int CompanionId { get; set; }
        [Column("companion_level")]
        public int CompanionLevel { get; set; }
        [Column("skill_id")]
        public int SkillId { get; set; }
        [Column("skill_level")]
        public int SkillLevel { get; set; }

        public Companion Companion { get; set; }
        public CompanionSkill Skill { get; set; }
    }
}
