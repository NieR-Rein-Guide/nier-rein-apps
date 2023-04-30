using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_title_still_group")]
    public class EntityMTitleStillGroup
    {
        [Key(0)]
        public int TitleStillGroupId { get; set; } // 0x10

        [Key(1)]
        public int DisplayStillCount { get; set; } // 0x14

        [Key(2)]
        public int Weight { get; set; } // 0x18

        [Key(3)]
        public int Priority { get; set; } // 0x1C
    }
}
