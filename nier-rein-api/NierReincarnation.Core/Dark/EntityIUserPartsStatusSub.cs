using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_parts_status_sub")]
    public class EntityIUserPartsStatusSub
    {
        [Key(0)] // RVA: 0x1DEA3E8 Offset: 0x1DEA3E8 VA: 0x1DEA3E8
        public long UserId { get; set; }    // 0x10
        [Key(1)] // RVA: 0x1DEA428 Offset: 0x1DEA428 VA: 0x1DEA428
        public string UserPartsUuid { get; set; }
        [Key(2)] // RVA: 0x1DEA468 Offset: 0x1DEA468 VA: 0x1DEA468
        public int StatusIndex { get; set; }    // 0x20
        [Key(3)] // RVA: 0x1DEA4A8 Offset: 0x1DEA4A8 VA: 0x1DEA4A8
        public int PartsStatusSubLotteryId { get; set; }
        [Key(4)] // RVA: 0x1DEA4BC Offset: 0x1DEA4BC VA: 0x1DEA4BC
        public int Level { get; set; }  // 0x28
        [Key(5)] // RVA: 0x1DEA4D0 Offset: 0x1DEA4D0 VA: 0x1DEA4D0
        public StatusKindType StatusKindType { get; set; } // 0x2C
        [Key(6)] // RVA: 0x1DEA4E4 Offset: 0x1DEA4E4 VA: 0x1DEA4E4
        public StatusCalculationType StatusCalculationType { get; set; }  // 0x30
        [Key(7)] // RVA: 0x1DEA4F8 Offset: 0x1DEA4F8 VA: 0x1DEA4F8
        public int StatusChangeValue { get; set; }  // 0x34
        [Key(8)] // RVA: 0x1DEA50C Offset: 0x1DEA50C VA: 0x1DEA50C
        public long LatestVersion { get; set; } // 0x38
    }
}
