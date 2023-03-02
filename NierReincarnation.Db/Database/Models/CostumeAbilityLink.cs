using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models
{
    [Table("costume_ability_link")]
    internal class CostumeAbilityLink
    {
        public int CostumeId { get; set; }

        public int AbilitySlot { get; set; }

        public int AbilityId { get; set; }

        public int AbilityLevel { get; set; }

        [ForeignKey(nameof(CostumeId))]
        public virtual Costume Costume { get; set; }

        public virtual CostumeAbility CostumeAbility { get; set; }
    }
}
