using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMNaviCutInContentGroup))]
public class EntityMNaviCutInContentGroup
{
    [Key(0)]
    public int NaviCutInContentGroupId { get; set; }

    [Key(1)]
    public int ContentIndex { get; set; }

    [Key(2)]
    public int NaviCutInTextId { get; set; }
}
