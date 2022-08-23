using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_release_condition_big_hunt_score")]
    public class EntityMQuestReleaseConditionBigHuntScore
    {
        [Key(0)] // RVA: 0x1DE2528 Offset: 0x1DE2528 VA: 0x1DE2528
        public int QuestReleaseConditionId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DE2568 Offset: 0x1DE2568 VA: 0x1DE2568
        public int BigHuntBossId { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DE257C Offset: 0x1DE257C VA: 0x1DE257C
        public long NecessaryScore { get; set; } // 0x18
	}
}
