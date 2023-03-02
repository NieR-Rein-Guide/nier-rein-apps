using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_event_quest_guerrilla_free_open")]
    public class EntityIUserEventQuestGuerrillaFreeOpen
    {
        [Key(0)] // RVA: 0x1EAC0FC Offset: 0x1EAC0FC VA: 0x1EAC0FC
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1EAC13C Offset: 0x1EAC13C VA: 0x1EAC13C
        public long StartDatetime { get; set; }
        [Key(2)] // RVA: 0x1EAC150 Offset: 0x1EAC150 VA: 0x1EAC150
        public int OpenMinutes { get; set; }
        [Key(3)] // RVA: 0x1EAC164 Offset: 0x1EAC164 VA: 0x1EAC164
        public int DailyOpenedCount { get; set; }
        [Key(4)] // RVA: 0x1EAC178 Offset: 0x1EAC178 VA: 0x1EAC178
        public long LatestVersion { get; set; }
	}
}
