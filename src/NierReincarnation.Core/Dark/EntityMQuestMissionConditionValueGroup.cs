using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_mission_condition_value_group")]
public class EntityMQuestMissionConditionValueGroup
{
    [Key(0)]
    public int QuestMissionConditionValueGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int ConditionValue { get; set; }
}
