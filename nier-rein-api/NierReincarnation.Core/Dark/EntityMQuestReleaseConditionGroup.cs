using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_release_condition_group")]
    public class EntityMQuestReleaseConditionGroup
    {
        [Key(0)] // RVA: 0x1DE264C Offset: 0x1DE264C VA: 0x1DE264C
        public int QuestReleaseConditionGroupId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DE268C Offset: 0x1DE268C VA: 0x1DE268C
        public int SortOrder { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DE26CC Offset: 0x1DE26CC VA: 0x1DE26CC
        public QuestReleaseConditionType QuestReleaseConditionType { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DE26E0 Offset: 0x1DE26E0 VA: 0x1DE26E0
        public int QuestReleaseConditionId { get; set; } // 0x1C
	}
}
