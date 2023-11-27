using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMShopReplaceableGem))]
public class EntityMShopReplaceableGem
{
    [Key(0)]
    public int LineupUpdateCountLowerLimit { get; set; }

    [Key(1)]
    public int NecessaryGem { get; set; }
}
