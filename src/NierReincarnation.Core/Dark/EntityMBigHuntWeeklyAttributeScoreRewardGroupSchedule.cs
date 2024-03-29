using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBigHuntWeeklyAttributeScoreRewardGroupSchedule))]
public class EntityMBigHuntWeeklyAttributeScoreRewardGroupSchedule
{
    [Key(0)]
    public int BigHuntWeeklyAttributeScoreRewardGroupScheduleId { get; set; }

    [Key(1)]
    public AttributeType AttributeType { get; set; }

    [Key(2)]
    public int GroupIndex { get; set; }

    [Key(3)]
    public int BigHuntScoreRewardGroupId { get; set; }

    [Key(4)]
    public long StartDatetime { get; set; }
}
