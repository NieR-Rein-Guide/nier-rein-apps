using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("weapon_story_link")]
    class WeaponStoryLink
    {
        [Column("weapon_id")] 
        public int WeaponId { get; set; }
        [Column("weapon_story_id")] 
        public int WeaponStoryId { get; set; }

        public Weapon Weapon { get; set; }
        public WeaponStory Story { get; set; }
    }
}
