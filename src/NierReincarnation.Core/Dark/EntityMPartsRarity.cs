using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMPartsRarity))]
public class EntityMPartsRarity
{
    [Key(0)]
    public RarityType RarityType { get; set; }

    [Key(1)]
    public int PartsLevelUpRateGroupId { get; set; }

    [Key(2)]
    public int PartsLevelUpPriceGroupId { get; set; }

    [Key(3)]
    public int SellPriceNumericalFunctionId { get; set; }
}
