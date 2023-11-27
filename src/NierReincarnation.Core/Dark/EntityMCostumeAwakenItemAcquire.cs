using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeAwakenItemAcquire))]
public class EntityMCostumeAwakenItemAcquire
{
    [Key(0)]
    public int CostumeAwakenItemAcquireId { get; set; }

    [Key(1)]
    public PossessionType PossessionType { get; set; }

    [Key(2)]
    public int PossessionId { get; set; }

    [Key(3)]
    public int Count { get; set; }
}
