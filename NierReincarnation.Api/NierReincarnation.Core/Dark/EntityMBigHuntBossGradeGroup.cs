using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_big_hunt_boss_grade_group")]
public class EntityMBigHuntBossGradeGroup
{
    [Key(0)]
    public int BigHuntBossGradeGroupId { get; set; }

    [Key(1)]
    public long NecessaryScore { get; set; }

    [Key(2)]
    public int AssetGradeIconId { get; set; }
}
