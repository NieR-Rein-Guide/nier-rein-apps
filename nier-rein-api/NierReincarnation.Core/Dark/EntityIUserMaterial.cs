using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_material")]
    public class EntityIUserMaterial
    {
        [Key(0)] // RVA: 0x1DE67AC Offset: 0x1DE67AC VA: 0x1DE67AC
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE67EC Offset: 0x1DE67EC VA: 0x1DE67EC
        public int MaterialId { get; set; }
        [Key(2)] // RVA: 0x1DE682C Offset: 0x1DE682C VA: 0x1DE682C
        public int Count { get; set; }
        [Key(3)] // RVA: 0x1DE6840 Offset: 0x1DE6840 VA: 0x1DE6840
        public long FirstAcquisitionDatetime { get; set; }
        [Key(4)] // RVA: 0x1DE6854 Offset: 0x1DE6854 VA: 0x1DE6854
        public long LatestVersion { get; set; }
	}
}
