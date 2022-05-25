using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("companion")]
    class Companion
    {
        [Key]
        [Column("companion_id")]
        public int CompanionId { get; set; }
        [Column("attribute")]
        public string Attribute { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("release_time")]
        public DateTimeOffset ReleaseTime { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("story")]
        public string Story { get; set; }
        [Column("image_path_base")]
        public string ImagePathBase { get; set; }

        public List<CompanionSkillLink> Skill { get; set; }
        public List<CompanionAbilityLink> Ability { get; set; }
        public List<CompanionStat> Stats { get; set; }
    }
}
