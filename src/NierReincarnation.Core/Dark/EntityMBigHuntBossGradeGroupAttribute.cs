using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBigHuntBossGradeGroupAttribute))]
public class EntityMBigHuntBossGradeGroupAttribute
{
    [Key(0)]
    public AttributeType AttributeType { get; set; }

    [Key(1)]
    public int BigHuntBossGradeGroupId { get; set; }
}
