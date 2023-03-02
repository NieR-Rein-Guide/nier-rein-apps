using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models
{
    [Table("companion_ability_link")]
    internal class CompanionAbilityLink
    {
        public int CompanionId { get; set; }

        public int CompanionLevel { get; set; }

        public int AbilityId { get; set; }

        public int AbilityLevel { get; set; }

        [ForeignKey(nameof(CompanionId))]
        public virtual Companion Companion { get; set; }

        public virtual CompanionAbility Ability { get; set; }
    }
}
