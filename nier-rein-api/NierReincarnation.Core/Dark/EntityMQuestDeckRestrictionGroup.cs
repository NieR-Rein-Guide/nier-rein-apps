using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_deck_restriction_group")]
    public class EntityMQuestDeckRestrictionGroup
    {
        [Key(0)] // RVA: 0x1DDEA9C Offset: 0x1DDEA9C VA: 0x1DDEA9C
        public int QuestDeckRestrictionGroupId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DDEADC Offset: 0x1DDEADC VA: 0x1DDEADC
        public int SlotNumber { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DDEB1C Offset: 0x1DDEB1C VA: 0x1DDEB1C
        public QuestDeckRestrictionType QuestDeckRestrictionType { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DDEB30 Offset: 0x1DDEB30 VA: 0x1DDEB30
        public int RestrictionValue { get; set; } // 0x1C
	}
}
