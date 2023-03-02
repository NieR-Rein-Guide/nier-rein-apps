using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_companion")]
    public class EntityIUserCompanion
    {
        [Key(0)] // RVA: 0x1DE83B8 Offset: 0x1DE83B8 VA: 0x1DE83B8
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE83F8 Offset: 0x1DE83F8 VA: 0x1DE83F8
        public string UserCompanionUuid { get; set; }
        [Key(2)] // RVA: 0x1DE8438 Offset: 0x1DE8438 VA: 0x1DE8438
        public int CompanionId { get; set; }    // 0x20
        [Key(3)] // RVA: 0x1DE844C Offset: 0x1DE844C VA: 0x1DE844C
        public int HeadupDisplayViewId { get; set; }
        [Key(4)] // RVA: 0x1DE8460 Offset: 0x1DE8460 VA: 0x1DE8460
        public int Level { get; set; }  // 0x28
        [Key(5)] // RVA: 0x1DE8474 Offset: 0x1DE8474 VA: 0x1DE8474
        public long AcquisitionDatetime { get; set; }
        [Key(6)] // RVA: 0x1DE8488 Offset: 0x1DE8488 VA: 0x1DE8488
        public long LatestVersion { get; set; }
	}
}
