using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_side_story_quest_scene")]
    public class EntityMSideStoryQuestScene
    {
        [Key(0)]
        public int SideStoryQuestId { get; set; } // 0x10

        [Key(1)]
        public int SideStoryQuestSceneId { get; set; } // 0x14

        [Key(2)]
        public int SortOrder { get; set; } // 0x18

        [Key(3)]
        public int AssetBackgroundId { get; set; } // 0x1C

        [Key(4)]
        public int EventMapNumberUpper { get; set; } // 0x20

        [Key(5)]
        public int EventMapNumberLower { get; set; } // 0x24
    }
}
