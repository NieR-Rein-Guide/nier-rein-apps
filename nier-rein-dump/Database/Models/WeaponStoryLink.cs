using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("weapon_story_link")]
    internal class WeaponStoryLink
    {
        public int WeaponId { get; set; }

        public int WeaponStoryId { get; set; }

        [ForeignKey(nameof(WeaponId))]
        public Weapon Weapon { get; set; }

        [ForeignKey(nameof(WeaponStoryId))]
        public WeaponStory Story { get; set; }
    }
}
