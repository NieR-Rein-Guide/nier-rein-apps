using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_main_quest_season")]
    public class EntityMMainQuestSeason
    {
        [Key(0)] // RVA: 0x1DDBD18 Offset: 0x1DDBD18 VA: 0x1DDBD18
        public int MainQuestSeasonId { get; set; }
        [Key(1)] // RVA: 0x1DDBD58 Offset: 0x1DDBD58 VA: 0x1DDBD58
        public int SortOrder { get; set; }
    }
}
