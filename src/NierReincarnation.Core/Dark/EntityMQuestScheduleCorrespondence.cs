using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_schedule_correspondence")]
public class EntityMQuestScheduleCorrespondence
{
    [Key(0)]
    public int QuestId { get; set; }

    [Key(1)]
    public int QuestScheduleId { get; set; }
}
