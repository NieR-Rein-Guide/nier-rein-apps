using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models
{
    [Table("weapon_ability_link")]
    internal class WeaponAbilityLink
    {
        public int WeaponId { get; set; }

        public int SlotNumber { get; set; }

        public int AbilityId { get; set; }

        public int AbilityLevel { get; set; }

        public WeaponAbility WeaponAbility { get; set; }

        [ForeignKey(nameof(WeaponId))]
        public Weapon Weapon { get; set; }
    }
}
