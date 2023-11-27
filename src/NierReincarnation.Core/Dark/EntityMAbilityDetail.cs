using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMAbilityDetail))]
public class EntityMAbilityDetail
{
    [Key(0)]
    public int AbilityDetailId { get; set; }

    [Key(1)]
    public int NameAbilityTextId { get; set; }

    [Key(2)]
    public int DescriptionAbilityTextId { get; set; }

    [Key(3)]
    public int AbilityBehaviourGroupId { get; set; }

    [Key(4)]
    public int AssetCategoryId { get; set; }

    [Key(5)]
    public int AssetVariationId { get; set; }
}
