using System.ComponentModel.DataAnnotations.Schema;

namespace NierReincarnation.Db.Database.Models;

[Table("costume_ability")]
internal class CostumeAbility
{
    public int AbilityId { get; set; }

    public int AbilityLevel { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImagePathBase { get; set; }

    public string[] BehaviourTypes { get; set; }

    public virtual ICollection<CostumeAbilityLink> Costume { get; set; }
}
