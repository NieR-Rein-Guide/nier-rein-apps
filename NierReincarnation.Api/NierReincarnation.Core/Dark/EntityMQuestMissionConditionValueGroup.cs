using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_mission_condition_value_group")]
    public class EntityMQuestMissionConditionValueGroup
    {
        [Key(0)] // RVA: 0x1DE2248 Offset: 0x1DE2248 VA: 0x1DE2248
        public int QuestMissionConditionValueGroupId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DE2288 Offset: 0x1DE2288 VA: 0x1DE2288
        public int SortOrder { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DE22C8 Offset: 0x1DE22C8 VA: 0x1DE22C8
        public int ConditionValue { get; set; } // 0x18
    }
}
