using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_first_clear_reward_group")]
    public class EntityMQuestFirstClearRewardGroup
    {
        [Key(0)] // RVA: 0x1DE20A8 Offset: 0x1DE20A8 VA: 0x1DE20A8
        public int QuestFirstClearRewardGroupId { get; set; }
        [Key(1)] // RVA: 0x1DE20E8 Offset: 0x1DE20E8 VA: 0x1DE20E8
        public QuestFirstClearRewardType QuestFirstClearRewardType { get; set; }
        [Key(2)] // RVA: 0x1DE2128 Offset: 0x1DE2128 VA: 0x1DE2128
        public int SortOrder { get; set; }
        [Key(3)] // RVA: 0x1DE2168 Offset: 0x1DE2168 VA: 0x1DE2168
        public PossessionType PossessionType { get; set; }
        [Key(4)] // RVA: 0x1DE217C Offset: 0x1DE217C VA: 0x1DE217C
        public int PossessionId { get; set; }
        [Key(5)] // RVA: 0x1DE2190 Offset: 0x1DE2190 VA: 0x1DE2190
        public int Count { get; set; }
        [Key(6)] // RVA: 0x1DE21A4 Offset: 0x1DE21A4 VA: 0x1DE21A4
        public bool IsPickup { get; set; }
	}
}
