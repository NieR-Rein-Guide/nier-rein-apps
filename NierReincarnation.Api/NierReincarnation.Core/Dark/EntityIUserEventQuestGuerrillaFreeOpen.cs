using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_event_quest_guerrilla_free_open")]
    public class EntityIUserEventQuestGuerrillaFreeOpen
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public long StartDatetime { get; set; } // 0x18

        [Key(2)]
        public int OpenMinutes { get; set; } // 0x20

        [Key(3)]
        public int DailyOpenedCount { get; set; } // 0x24

        [Key(4)]
        public long LatestVersion { get; set; } // 0x28
    }
}
