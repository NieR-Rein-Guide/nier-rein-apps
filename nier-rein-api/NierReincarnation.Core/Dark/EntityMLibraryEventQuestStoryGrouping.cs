using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_library_event_quest_story_grouping")]
    public class EntityMLibraryEventQuestStoryGrouping
    {
        [Key(0)]
        public int LibraryStoryGroupingId { get; set; } // 0x10
        [Key(1)]
        public int EventQuestChapterId { get; set; } // 0x14
        [Key(2)]
        public int SortOrder { get; set; } // 0x18
    }
}