using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeAwakenEffectGroup))]
public class EntityMCostumeAwakenEffectGroup
{
    [Key(0)]
    public int CostumeAwakenEffectGroupId { get; set; }

    [Key(1)]
    public int AwakenStep { get; set; }

    [Key(2)]
    public CostumeAwakenEffectType CostumeAwakenEffectType { get; set; }

    [Key(3)]
    public int CostumeAwakenEffectId { get; set; }
}
