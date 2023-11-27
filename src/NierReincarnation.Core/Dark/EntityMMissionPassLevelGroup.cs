using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMMissionPassLevelGroup))]
public class EntityMMissionPassLevelGroup
{
    [Key(0)]
    public int MissionPassLevelGroupId { get; set; }

    [Key(1)]
    public int Level { get; set; }

    [Key(2)]
    public int NecessaryPoint { get; set; }
}
