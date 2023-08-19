using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_big_hunt_boss_grade_group_attribute")]
public class EntityMBigHuntBossGradeGroupAttribute
{
    [Key(0)]
    public AttributeType AttributeType { get; set; }

    [Key(1)]
    public int BigHuntBossGradeGroupId { get; set; }
}
