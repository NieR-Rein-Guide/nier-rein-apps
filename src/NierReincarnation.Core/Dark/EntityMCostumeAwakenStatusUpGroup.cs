using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeAwakenStatusUpGroup))]
public class EntityMCostumeAwakenStatusUpGroup
{
    [Key(0)]
    public int CostumeAwakenStatusUpGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public StatusKindType StatusKindType { get; set; }

    [Key(3)]
    public StatusCalculationType StatusCalculationType { get; set; }

    [Key(4)]
    public int EffectValue { get; set; }
}
