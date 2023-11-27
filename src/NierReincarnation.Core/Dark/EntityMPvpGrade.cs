using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMPvpGrade))]
public class EntityMPvpGrade
{
    [Key(0)]
    public int PvpGradeId { get; set; }

    [Key(1)]
    public int NecessaryPvpPoint { get; set; }

    [Key(2)]
    public int IconAssetId { get; set; }

    [Key(3)]
    public int PvpGradeWeeklyRewardGroupId { get; set; }

    [Key(4)]
    public int PvpGradeOneMatchRewardGroupId { get; set; }
}
