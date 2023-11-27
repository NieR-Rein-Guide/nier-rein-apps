using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCompleteMissionGroup))]
public class EntityMCompleteMissionGroup
{
    [Key(0)]
    public int MissionId { get; set; }

    [Key(1)]
    public PossessionType PossessionType { get; set; }

    [Key(2)]
    public int PossessionId { get; set; }

    [Key(3)]
    public int SortOrder { get; set; }
}
