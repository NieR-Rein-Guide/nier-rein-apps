using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_big_hunt_progress_status")]
    public class EntityIUserBigHuntProgressStatus
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int CurrentBigHuntBossQuestId { get; set; } // 0x18

        [Key(2)]
        public int CurrentBigHuntQuestId { get; set; } // 0x1C

        [Key(3)]
        public int CurrentQuestSceneId { get; set; } // 0x20

        [Key(4)]
        public bool IsDryRun { get; set; } // 0x24

        [Key(5)]
        public long LatestVersion { get; set; } // 0x28
    }
}
