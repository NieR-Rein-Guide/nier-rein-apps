using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("costume_skill_link")]
    class CostumeSkillLink
    {
        [Column("costume_id")]
        public int CostumeId { get; set; }
        [Column("skill_id")]
        public int SkillId { get; set; }
        [Column("skill_level")]
        public int SkillLevel { get; set; }

        public Costume Costume { get; set; }
        public CostumeSkill CostumeSkill { get; set; }
    }
}
