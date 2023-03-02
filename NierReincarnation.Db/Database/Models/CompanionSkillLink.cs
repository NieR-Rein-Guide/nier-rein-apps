using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models
{
    [Table("companion_skill_link")]
    internal class CompanionSkillLink
    {
        public int CompanionId { get; set; }

        public int CompanionLevel { get; set; }

        public int SkillId { get; set; }

        public int SkillLevel { get; set; }

        [ForeignKey(nameof(CompanionId))]
        public virtual Companion Companion { get; set; }

        public virtual CompanionSkill Skill { get; set; }
    }
}
