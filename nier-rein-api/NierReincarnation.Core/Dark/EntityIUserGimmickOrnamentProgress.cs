using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_gimmick_ornament_progress")]
    public class EntityIUserGimmickOrnamentProgress
    {
        [Key(0)] // RVA: 0x1F858B8 Offset: 0x1F858B8 VA: 0x1F858B8
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1F858F8 Offset: 0x1F858F8 VA: 0x1F858F8
        public int GimmickSequenceScheduleId { get; set; }
        [Key(2)] // RVA: 0x1F85938 Offset: 0x1F85938 VA: 0x1F85938
        public int GimmickSequenceId { get; set; }
        [Key(3)] // RVA: 0x1F85978 Offset: 0x1F85978 VA: 0x1F85978
        public int GimmickId { get; set; }
        [Key(4)] // RVA: 0x1F859B8 Offset: 0x1F859B8 VA: 0x1F859B8
        public int GimmickOrnamentIndex { get; set; }
        [Key(5)] // RVA: 0x1F859F8 Offset: 0x1F859F8 VA: 0x1F859F8
        public int ProgressValueBit { get; set; }
        [Key(6)] // RVA: 0x1F85A0C Offset: 0x1F85A0C VA: 0x1F85A0C
        public long BaseDatetime { get; set; }
        [Key(7)] // RVA: 0x1F85A20 Offset: 0x1F85A20 VA: 0x1F85A20
        public long LatestVersion { get; set; }
	}
}
