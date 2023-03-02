using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("weapon_ability")]
internal class WeaponAbility
{
    public int AbilityId { get; set; }

    public int AbilityLevel { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImagePathBase { get; set; }

    public bool IsAwaken { get; set; }

    public virtual ICollection<WeaponAbilityLink> Weapons { get; set; }
}
