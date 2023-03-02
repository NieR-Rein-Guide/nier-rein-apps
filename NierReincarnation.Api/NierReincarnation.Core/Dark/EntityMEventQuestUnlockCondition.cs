using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_unlock_condition")]
    public class EntityMEventQuestUnlockCondition
    {
        [Key(0)]
        public EventQuestType EventQuestType { get; set; } // 0x10
        [Key(1)]
        public int CharacterId { get; set; } // 0x14
        [Key(2)]
        public int QuestId { get; set; } // 0x18
        [Key(3)]
        public UnlockConditionType UnlockConditionType { get; set; } // 0x1C
        [Key(4)]
        public int ConditionValue { get; set; } // 0x20
        [Key(5)]
        public int UnlockEvaluateConditionId { get; set; } // 0x24
    }
}