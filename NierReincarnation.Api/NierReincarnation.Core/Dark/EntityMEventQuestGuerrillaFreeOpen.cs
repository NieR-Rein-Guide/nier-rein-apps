using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_guerrilla_free_open")]
    public class EntityMEventQuestGuerrillaFreeOpen
    {
        [Key(0)] // RVA: 0x1E9F808 Offset: 0x1E9F808 VA: 0x1E9F808
        public int EventQuestGuerrillaFreeOpenId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1E9F848 Offset: 0x1E9F848 VA: 0x1E9F848
        public int OpenMinutes { get; set; } // 0x14
        [Key(2)] // RVA: 0x1E9F85C Offset: 0x1E9F85C VA: 0x1E9F85C
        public int DailyOpenMaxCount { get; set; } // 0x18
        [Key(3)] // RVA: 0x1E9F870 Offset: 0x1E9F870 VA: 0x1E9F870
        public long StartDatetime { get; set; } // 0x20
        [Key(4)] // RVA: 0x1E9F884 Offset: 0x1E9F884 VA: 0x1E9F884
        public long EndDatetime { get; set; } // 0x28
	}
}
