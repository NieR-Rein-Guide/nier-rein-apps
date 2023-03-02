using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_deck_restriction_group_unlock")]
    public class EntityMQuestDeckRestrictionGroupUnlock
    {
        [Key(0)]
        public int QuestDeckRestrictionGroupId { get; set; } // 0x10
        [Key(1)]
        public int UnlockEvaluateConditionId { get; set; } // 0x14
    }
}