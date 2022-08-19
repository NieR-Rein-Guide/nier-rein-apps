using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("companion_ability")]
    internal class CompanionAbility
    {
        public int AbilityId { get; set; }

        public int AbilityLevel { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePathBase { get; set; }

        public virtual ICollection<CompanionAbilityLink> Companions { get; set; }
    }
}
