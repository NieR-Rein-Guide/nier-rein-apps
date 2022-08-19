using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("costume_skill_link")]
    internal class CostumeSkillLink
    {
        public int CostumeId { get; set; }

        public int SkillId { get; set; }

        public int SkillLevel { get; set; }

        [ForeignKey(nameof(CostumeId))]
        public virtual Costume Costume { get; set; }

        public virtual CostumeSkill CostumeSkill { get; set; }
    }
}
