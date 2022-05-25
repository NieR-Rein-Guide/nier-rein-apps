using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("costume_ability_link")]
    class CostumeAbilityLink
    {
        [Column("costume_id")]
        public int CostumeId { get; set; }
        [Column("ability_slot")]
        public int AbilitySlot { get; set; }
        [Column("ability_id")]
        public int AbilityId { get; set; }
        [Column("ability_level")]
        public int AbilityLevel { get; set; }

        public Costume Costume { get; set; }
        public CostumeAbility CostumeAbility { get; set; }
    }
}
