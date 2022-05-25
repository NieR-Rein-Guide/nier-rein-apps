using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("weapon_ability_link")]
    class WeaponAbilityLink
    {
        [Column("weapon_id")]
        public int WeaponId { get; set; }
        [Column("slot_number")]
        public int SlotNumber { get; set; }
        [Column("ability_id")]
        public int AbilityId { get; set; }
        [Column("ability_level")]
        public int AbilityLevel { get; set; }

        public WeaponAbility WeaponAbility { get; set; }
        public Weapon Weapon { get; set; }
    }
}
