using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMShopItemContentEffect))]
public class EntityMShopItemContentEffect
{
    [Key(0)]
    public int ShopItemId { get; set; }

    [Key(1)]
    public EffectTargetType EffectTargetType { get; set; }

    [Key(2)]
    public EffectValueType EffectValueType { get; set; }

    [Key(3)]
    public int EffectValue { get; set; }
}
