using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_main_quest_season_route")]
    public class EntityIUserMainQuestSeasonRoute
    {
        [Key(0)] // RVA: 0x1EACF8C Offset: 0x1EACF8C VA: 0x1EACF8C
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1EACFCC Offset: 0x1EACFCC VA: 0x1EACFCC
        public int MainQuestSeasonId { get; set; }
        [Key(2)] // RVA: 0x1EAD00C Offset: 0x1EAD00C VA: 0x1EAD00C
        public int MainQuestRouteId { get; set; }
        [Key(3)] // RVA: 0x1EAD020 Offset: 0x1EAD020 VA: 0x1EAD020
        public long LatestVersion { get; set; }
	}
}
