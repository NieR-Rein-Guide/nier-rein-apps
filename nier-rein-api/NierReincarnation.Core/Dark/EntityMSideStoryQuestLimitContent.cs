using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_side_story_quest_limit_content")]
    public class EntityMSideStoryQuestLimitContent
    {
        [Key(0)]
        public int SideStoryQuestLimitContentId { get; set; } // 0x10
        [Key(1)]
        public int CharacterId { get; set; } // 0x14
        [Key(2)]
        public int EventQuestChapterId { get; set; } // 0x18
        [Key(3)]
        public int DifficultyType { get; set; } // 0x1C
        [Key(4)]
        public int NextSideStoryQuestId { get; set; } // 0x20
    }
}