using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCageOrnamentStillReleaseCondition))]
public class EntityMCageOrnamentStillReleaseCondition
{
    [Key(0)]
    public int CageOrnamentStillReleaseConditionId { get; set; }

    [Key(1)]
    public int CageOrnamentId { get; set; }
}
