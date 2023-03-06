using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("weapon_story")]
internal class WeaponStory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Story { get; set; }

    public virtual ICollection<WeaponStoryLink> Weapons { get; set; }
}
