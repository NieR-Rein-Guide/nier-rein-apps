using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBigHuntBossGradeGroup))]
public class EntityMBigHuntBossGradeGroup
{
    [Key(0)]
    public int BigHuntBossGradeGroupId { get; set; }

    [Key(1)]
    public long NecessaryScore { get; set; }

    [Key(2)]
    public int AssetGradeIconId { get; set; }
}
