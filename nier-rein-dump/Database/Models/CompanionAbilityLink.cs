using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("companion_ability_link")]
    class CompanionAbilityLink
    {
        [Column("companion_id")]
        public int CompanionId { get; set; }
        [Column("companion_level")]
        public int CompanionLevel { get; set; }
        [Column("ability_id")]
        public int AbilityId { get; set; }
        [Column("ability_level")]
        public int AbilityLevel { get; set; }

        public Companion Companion { get; set; }
        public CompanionAbility Ability { get; set; }
    }
}
