using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeAwaken))]
public class EntityMCostumeAwaken
{
    [Key(0)]
    public int CostumeId { get; set; }

    [Key(1)]
    public int CostumeAwakenEffectGroupId { get; set; }

    [Key(2)]
    public int CostumeAwakenStepMaterialGroupId { get; set; }

    [Key(3)]
    public int CostumeAwakenPriceGroupId { get; set; }
}
