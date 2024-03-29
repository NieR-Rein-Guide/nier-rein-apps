using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeAwakenPriceGroup))]
public class EntityMCostumeAwakenPriceGroup
{
    [Key(0)]
    public int CostumeAwakenPriceGroupId { get; set; }

    [Key(1)]
    public int AwakenStepLowerLimit { get; set; }

    [Key(2)]
    public int Gold { get; set; }
}
