using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMPvpGradeOneMatchRewardGroup))]
public class EntityMPvpGradeOneMatchRewardGroup
{
    [Key(0)]
    public int PvpGradeOneMatchRewardGroupId { get; set; }

    [Key(1)]
    public int PvpGradeOneMatchRewardId { get; set; }

    [Key(2)]
    public int Weight { get; set; }
}
