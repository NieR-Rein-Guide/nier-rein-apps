using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_side_story_quest")]
    public class EntityMSideStoryQuest
    {
        [Key(0)]
        public int SideStoryQuestId { get; set; } // 0x10
        [Key(1)]
        public int SideStoryQuestType { get; set; } // 0x14
        [Key(2)]
        public int TargetId { get; set; } // 0x18
    }
}