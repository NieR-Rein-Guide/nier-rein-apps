using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_side_story_quest")]
    public class EntityIUserSideStoryQuest
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int SideStoryQuestId { get; set; } // 0x18

        [Key(2)]
        public int HeadSideStoryQuestSceneId { get; set; } // 0x1C

        [Key(3)]
        public int SideStoryQuestStateType { get; set; } // 0x20

        [Key(4)]
        public long LatestVersion { get; set; } // 0x28
    }
}
