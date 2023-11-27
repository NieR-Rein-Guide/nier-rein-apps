using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMConsumableItemTerm))]
public class EntityMConsumableItemTerm
{
    [Key(0)]
    public int ConsumableItemTermId { get; set; }

    [Key(1)]
    public long StartDatetime { get; set; }

    [Key(2)]
    public long EndDatetime { get; set; }
}
