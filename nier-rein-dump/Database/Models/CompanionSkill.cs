using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("companion_skill")]
    internal class CompanionSkill
    {
        public int SkillId { get; set; }

        public int SkillLevel { get; set; }

        public int CooldownTime { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<CompanionSkillLink> Companions { get; set; }
    }
}
