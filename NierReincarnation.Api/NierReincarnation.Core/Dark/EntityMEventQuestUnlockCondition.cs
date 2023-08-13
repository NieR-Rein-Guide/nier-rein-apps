using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_event_quest_unlock_condition")]
public class EntityMEventQuestUnlockCondition
{
    [Key(0)]
    public EventQuestType EventQuestType { get; set; }

    [Key(1)]
    public int CharacterId { get; set; }

    [Key(2)]
    public int QuestId { get; set; }

    [Key(3)]
    public UnlockConditionType UnlockConditionType { get; set; }

    [Key(4)]
    public int ConditionValue { get; set; }

    [Key(5)]
    public int UnlockEvaluateConditionId { get; set; }
}
