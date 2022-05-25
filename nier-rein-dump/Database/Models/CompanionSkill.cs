using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("companion_skill")]
    class CompanionSkill
    {
        [Column("skill_id")]
        public int SkillId { get; set; }
        [Column("skill_level")]
        public int SkillLevel { get; set; }
        [Column("cooldown_time")]
        public int CooldownTime { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("short_description")]
        public string ShortDescription { get; set; }
        [Column("image_path")]
        public string ImagePath { get; set; }

        public List<CompanionSkillLink> Companions { get; set; }
    }
}
