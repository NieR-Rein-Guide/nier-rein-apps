using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReinDb.Database.Models
{
    [Table("weapon_story")]
    internal class WeaponStory
    {
        [Key]
        public int Id { get; set; }

        public string Story { get; set; }

        public virtual ICollection<WeaponStoryLink> Weapons { get; set; }
    }
}
