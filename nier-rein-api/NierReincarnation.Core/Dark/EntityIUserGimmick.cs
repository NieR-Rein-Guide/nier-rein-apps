using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_gimmick")]
    public class EntityIUserGimmick
    {
        [Key(0)] // RVA: 0x1F8577C Offset: 0x1F8577C VA: 0x1F8577C
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1F857BC Offset: 0x1F857BC VA: 0x1F857BC
        public int GimmickSequenceScheduleId { get; set; }
        [Key(2)] // RVA: 0x1F857FC Offset: 0x1F857FC VA: 0x1F857FC
        public int GimmickSequenceId { get; set; }
        [Key(3)] // RVA: 0x1F8583C Offset: 0x1F8583C VA: 0x1F8583C
        public int GimmickId { get; set; }
        [Key(4)] // RVA: 0x1F8587C Offset: 0x1F8587C VA: 0x1F8587C
        public bool IsGimmickCleared { get; set; }
        [Key(5)] // RVA: 0x1F85890 Offset: 0x1F85890 VA: 0x1F85890
        public long StartDatetime { get; set; }
        [Key(6)] // RVA: 0x1F858A4 Offset: 0x1F858A4 VA: 0x1F858A4
        public long LatestVersion { get; set; }
	}
}
