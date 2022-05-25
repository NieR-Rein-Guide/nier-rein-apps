using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_parts")]
    public class EntityIUserParts
    {
        [Key(0)] // RVA: 0x1DEA0A8 Offset: 0x1DEA0A8 VA: 0x1DEA0A8
        public long UserId { get; set; }    // 0x10
        [Key(1)] // RVA: 0x1DEA0E8 Offset: 0x1DEA0E8 VA: 0x1DEA0E8
        public string UserPartsUuid { get; set; }
        [Key(2)] // RVA: 0x1DEA128 Offset: 0x1DEA128 VA: 0x1DEA128
        public int PartsId { get; set; }    // 0x20
        [Key(3)] // RVA: 0x1DEA13C Offset: 0x1DEA13C VA: 0x1DEA13C
        public int Level { get; set; }
        [Key(4)] // RVA: 0x1DEA150 Offset: 0x1DEA150 VA: 0x1DEA150
        public int PartsStatusMainId { get; set; }  // 0x28
        [Key(5)] // RVA: 0x1DEA164 Offset: 0x1DEA164 VA: 0x1DEA164
        public bool IsProtected { get; set; }
        [Key(6)] // RVA: 0x1DEA178 Offset: 0x1DEA178 VA: 0x1DEA178
        public long AcquisitionDatetime { get; set; }
        [Key(7)] // RVA: 0x1DEA18C Offset: 0x1DEA18C VA: 0x1DEA18C
        public long LatestVersion { get; set; }
	}
}
