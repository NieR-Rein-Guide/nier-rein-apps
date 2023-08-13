using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_mission")]
public class EntityMQuestMission
{
    [Key(0)]
    public int QuestMissionId { get; set; }

    [Key(1)]
    public QuestMissionConditionType QuestMissionConditionType { get; set; }

    [Key(2)]
    public int ConditionValue { get; set; }

    [Key(3)]
    public int QuestMissionRewardId { get; set; }

    [Key(4)]
    public int QuestMissionConditionValueGroupId { get; set; }
}
