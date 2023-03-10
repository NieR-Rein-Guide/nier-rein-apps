using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_side_story_quest_scene_progress_status")]
    public class EntityIUserSideStoryQuestSceneProgressStatus
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10
        [Key(1)]
        public int CurrentSideStoryQuestId { get; set; } // 0x18
        [Key(2)]
        public int CurrentSideStoryQuestSceneId { get; set; } // 0x1C
        [Key(3)]
        public long LatestVersion { get; set; } // 0x20
    }
}