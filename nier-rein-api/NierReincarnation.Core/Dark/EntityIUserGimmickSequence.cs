using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_gimmick_sequence")]
    public class EntityIUserGimmickSequence
    {
        [Key(0)] // RVA: 0x1F85A34 Offset: 0x1F85A34 VA: 0x1F85A34
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1F85A74 Offset: 0x1F85A74 VA: 0x1F85A74
        public int GimmickSequenceScheduleId { get; set; }
        [Key(2)] // RVA: 0x1F85AB4 Offset: 0x1F85AB4 VA: 0x1F85AB4
        public int GimmickSequenceId { get; set; }
        [Key(3)] // RVA: 0x1F85AC8 Offset: 0x1F85AC8 VA: 0x1F85AC8
        public bool IsGimmickSequenceCleared { get; set; }
        [Key(4)] // RVA: 0x1F85ADC Offset: 0x1F85ADC VA: 0x1F85ADC
        public long ClearDatetime { get; set; }
        [Key(5)] // RVA: 0x1F85AF0 Offset: 0x1F85AF0 VA: 0x1F85AF0
        public long LatestVersion { get; set; }
	}
}
