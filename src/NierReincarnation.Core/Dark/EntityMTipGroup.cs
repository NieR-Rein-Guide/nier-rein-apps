using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMTipGroup))]
public class EntityMTipGroup
{
    [Key(0)]
    public int TipGroupId { get; set; }

    [Key(1)]
    public int NameTextId { get; set; }
}
