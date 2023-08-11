using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_release_condition_list")]
    public class EntityMQuestReleaseConditionList
    {
        [Key(0)] // RVA: 0x1DE26F4 Offset: 0x1DE26F4 VA: 0x1DE26F4
        public int QuestReleaseConditionListId { get; set; }

        [Key(1)] // RVA: 0x1DE2734 Offset: 0x1DE2734 VA: 0x1DE2734
        public int QuestReleaseConditionGroupId { get; set; }

        [Key(2)] // RVA: 0x1DE2748 Offset: 0x1DE2748 VA: 0x1DE2748
        public ConditionOperationType ConditionOperationType { get; set; }
    }
}
