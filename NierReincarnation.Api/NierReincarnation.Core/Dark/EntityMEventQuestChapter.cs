using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    // Dark.EntityMEventQuestChapter
    [MessagePackObject]
    [MemoryTable("m_event_quest_chapter")]
    public class EntityMEventQuestChapter
    {
        [Key(0)]
        public int EventQuestChapterId { get; set; } // 0x10

        [Key(1)]
        public EventQuestType EventQuestType { get; set; } // 0x14

        [Key(2)]
        public int SortOrder { get; set; } // 0x18

        [Key(3)]
        public int NameEventQuestTextId { get; set; } // 0x1C

        [Key(4)]
        public int BannerAssetId { get; set; } // 0x20

        [Key(5)]
        public int EventQuestLinkId { get; set; } // 0x24

        [Key(6)]
        public int EventQuestDisplayItemGroupId { get; set; } // 0x28

        [Key(7)]
        public int EventQuestSequenceGroupId { get; set; } // 0x2C

        [Key(8)]
        public long StartDatetime { get; set; } // 0x30

        [Key(9)]
        public long EndDatetime { get; set; } // 0x38

        [Key(10)]
        public int DisplaySortOrder { get; set; }   // 0x40
    }
}
