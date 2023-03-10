using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_main_quest_main_flow_status")]
    public class EntityIUserMainQuestMainFlowStatus
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10
        [Key(1)]
        public int CurrentMainQuestRouteId { get; set; } // 0x18
        [Key(2)]
        public int CurrentQuestSceneId { get; set; } // 0x1C
        [Key(3)]
        public int HeadQuestSceneId { get; set; } // 0x20
        [Key(4)]
        public bool IsReachedLastQuestScene { get; set; } // 0x24
        [Key(5)]
        public long LatestVersion { get; set; } // 0x28
    }
}