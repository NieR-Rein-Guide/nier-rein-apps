using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_costume")]
    public class EntityIUserCostume
    {
        [Key(0)] // RVA: 0x1DE8600 Offset: 0x1DE8600 VA: 0x1DE8600
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE8640 Offset: 0x1DE8640 VA: 0x1DE8640
        public string UserCostumeUuid { get; set; } // 0x18
        [Key(2)] // RVA: 0x1DE8680 Offset: 0x1DE8680 VA: 0x1DE8680
        public int CostumeId { get; set; }  // 0x20
        [Key(3)] // RVA: 0x1DE8694 Offset: 0x1DE8694 VA: 0x1DE8694
        public int LimitBreakCount { get; set; }    // 0x24
        [Key(4)] // RVA: 0x1DE86A8 Offset: 0x1DE86A8 VA: 0x1DE86A8
        public int Level { get; set; }
        [Key(5)] // RVA: 0x1DE86BC Offset: 0x1DE86BC VA: 0x1DE86BC
        public int Exp { get; set; }
        [Key(6)] // RVA: 0x1DE86D0 Offset: 0x1DE86D0 VA: 0x1DE86D0
        public int HeadupDisplayViewId { get; set; }
        [Key(7)] // RVA: 0x1DE86E4 Offset: 0x1DE86E4 VA: 0x1DE86E4
        public long AcquisitionDatetime { get; set; }
        [Key(8)] // RVA: 0x1EAB818 Offset: 0x1EAB818 VA: 0x1EAB818
        public int AwakenCount { get; set; }
        [Key(9)] // RVA: 0x1DE86F8 Offset: 0x1DE86F8 VA: 0x1DE86F8
        public long LatestVersion { get; set; }
	}
}
