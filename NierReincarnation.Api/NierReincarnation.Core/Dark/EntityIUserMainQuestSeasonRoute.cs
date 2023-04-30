using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_main_quest_season_route")]
    public class EntityIUserMainQuestSeasonRoute
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int MainQuestSeasonId { get; set; } // 0x18

        [Key(2)]
        public int MainQuestRouteId { get; set; } // 0x1C

        [Key(3)]
        public long LatestVersion { get; set; } // 0x20
    }
}
