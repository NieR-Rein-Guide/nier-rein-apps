using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeAwakenStepMaterialGroup))]
public class EntityMCostumeAwakenStepMaterialGroup
{
    [Key(0)]
    public int CostumeAwakenStepMaterialGroupId { get; set; }

    [Key(1)]
    public int AwakenStepLowerLimit { get; set; }

    [Key(2)]
    public int CostumeAwakenMaterialGroupId { get; set; }
}
