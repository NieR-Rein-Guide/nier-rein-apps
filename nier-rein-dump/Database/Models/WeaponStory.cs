using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("weapon_story")]
    class WeaponStory
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("story")]
        public string Story { get; set; }

        public List<WeaponStoryLink> Weapons { get; set; }
    }
}
