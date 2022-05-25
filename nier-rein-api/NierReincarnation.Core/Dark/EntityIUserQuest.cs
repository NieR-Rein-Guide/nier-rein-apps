using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_quest")]
    public class EntityIUserQuest
    {
        [Key(0)] // RVA: 0x1DEA8E8 Offset: 0x1DEA8E8 VA: 0x1DEA8E8
        public long UserId { get; set; }    // 0x10
        [Key(1)] // RVA: 0x1DEA928 Offset: 0x1DEA928 VA: 0x1DEA928
        public int QuestId { get; set; }    // 0x18
        [Key(2)] // RVA: 0x1DEA968 Offset: 0x1DEA968 VA: 0x1DEA968
        public int QuestStateType { get; set; } // 0x1C
        [Key(3)] // RVA: 0x1DEA97C Offset: 0x1DEA97C VA: 0x1DEA97C
        public bool IsBattleOnly { get; set; }  // 0x20
        [Key(4)] // RVA: 0x1DEA990 Offset: 0x1DEA990 VA: 0x1DEA990
        public long LatestStartDatetime { get; set; }   // 0x28
        [Key(5)] // RVA: 0x1DEA9A4 Offset: 0x1DEA9A4 VA: 0x1DEA9A4
        public int ClearCount { get; set; } // 0x30
        [Key(6)] // RVA: 0x1DEA9B8 Offset: 0x1DEA9B8 VA: 0x1DEA9B8
        public int DailyClearCount { get; set; }    // 0x34
        [Key(7)] // RVA: 0x1DEA9CC Offset: 0x1DEA9CC VA: 0x1DEA9CC
        public long LastClearDatetime { get; set; } // 0x38
        [Key(8)] // RVA: 0x1DEA9E0 Offset: 0x1DEA9E0 VA: 0x1DEA9E0
        public int ShortestClearFrames { get; set; }
        [Key(9)] // RVA: 0x1DEA9F4 Offset: 0x1DEA9F4 VA: 0x1DEA9F4
        public long LatestVersion { get; set; }
	}
}
