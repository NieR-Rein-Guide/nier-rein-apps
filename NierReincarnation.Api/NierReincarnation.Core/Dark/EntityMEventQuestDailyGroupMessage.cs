using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_daily_group_message")]
    public class EntityMEventQuestDailyGroupMessage
    {
        [Key(0)]
        public int EventQuestDailyGroupMessageId { get; set; } // 0x10

        [Key(1)]
        public int OddsNumber { get; set; } // 0x14

        [Key(2)]
        public int Weight { get; set; } // 0x18

        [Key(3)]
        public int BeforeClearMessageTextId { get; set; } // 0x1C

        [Key(4)]
        public int AfterClearMessageTextId { get; set; } // 0x20
    }
}
