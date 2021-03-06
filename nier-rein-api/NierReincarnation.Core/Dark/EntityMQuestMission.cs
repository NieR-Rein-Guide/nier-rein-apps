using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_mission")]
    public class EntityMQuestMission
    {
        [Key(0)] // RVA: 0x1DE21B8 Offset: 0x1DE21B8 VA: 0x1DE21B8
        public int QuestMissionId { get; set; }
        [Key(1)] // RVA: 0x1DE21F8 Offset: 0x1DE21F8 VA: 0x1DE21F8
        public QuestMissionConditionType QuestMissionConditionType { get; set; }
        [Key(2)] // RVA: 0x1DE220C Offset: 0x1DE220C VA: 0x1DE220C
        public int ConditionValue { get; set; }
        [Key(3)] // RVA: 0x1DE2220 Offset: 0x1DE2220 VA: 0x1DE2220
        public int QuestMissionRewardId { get; set; }
        [Key(4)] // RVA: 0x1DE2234 Offset: 0x1DE2234 VA: 0x1DE2234
        public int QuestMissionConditionValueGroupId { get; set; }
	}
}
