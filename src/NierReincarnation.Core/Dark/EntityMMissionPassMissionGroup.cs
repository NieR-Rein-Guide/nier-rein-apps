using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMMissionPassMissionGroup))]
public class EntityMMissionPassMissionGroup
{
    [Key(0)]
    public int MissionPassId { get; set; }

    [Key(1)]
    public int MissionGroupId { get; set; }
}
