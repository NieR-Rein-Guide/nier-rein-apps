using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_release_condition_user_level")]
public class EntityMQuestReleaseConditionUserLevel
{
    [Key(0)]
    public int QuestReleaseConditionId { get; set; }

    [Key(1)]
    public int UserLevel { get; set; }
}
