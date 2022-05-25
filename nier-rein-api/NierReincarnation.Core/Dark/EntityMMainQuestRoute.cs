using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_main_quest_route")]
    public class EntityMMainQuestRoute
    {
        [Key(0)] // RVA: 0x1DDBC9C Offset: 0x1DDBC9C VA: 0x1DDBC9C
        public int MainQuestRouteId { get; set; }
        [Key(1)] // RVA: 0x1DDBCDC Offset: 0x1DDBCDC VA: 0x1DDBCDC
        public int MainQuestSeasonId { get; set; }
        [Key(2)] // RVA: 0x1DDBCF0 Offset: 0x1DDBCF0 VA: 0x1DDBCF0
        public int SortOrder { get; set; }
        [Key(3)] // RVA: 0x1DDBD04 Offset: 0x1DDBD04 VA: 0x1DDBD04
        public int CharacterId { get; set; }
	}
}
