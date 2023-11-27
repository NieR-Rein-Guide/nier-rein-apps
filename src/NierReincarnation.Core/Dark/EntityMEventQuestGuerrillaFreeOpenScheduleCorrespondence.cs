using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMEventQuestGuerrillaFreeOpenScheduleCorrespondence))]
public class EntityMEventQuestGuerrillaFreeOpenScheduleCorrespondence
{
    [Key(0)]
    public int QuestId { get; set; }

    [Key(1)]
    public int QuestScheduleId { get; set; }
}
