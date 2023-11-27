using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMPvpGradeWeeklyRewardGroup))]
public class EntityMPvpGradeWeeklyRewardGroup
{
    [Key(0)]
    public int PvpGradeWeeklyRewardGroupId { get; set; }

    [Key(1)]
    public int PvpRewardId { get; set; }

    [Key(2)]
    public int SortOrder { get; set; }
}
