using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_limit_content")]
    public class EntityMEventQuestLimitContent
    {
        [Key(0)]
        public int EventQuestLimitContentId { get; set; } // 0x10

        [Key(1)]
        public int CostumeId { get; set; } // 0x14

        [Key(2)]
        public int UnlockEvaluateConditionId { get; set; } // 0x18

        [Key(3)]
        public int SortOrder { get; set; } // 0x1C

        [Key(4)]
        public int DeckGroupNumber { get; set; } // 0x20

        [Key(5)]
        public long StartDatetime { get; set; } // 0x28

        [Key(6)]
        public long EndDatetime { get; set; } // 0x30
    }
}
