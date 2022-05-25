using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_weapon_note")]
    public class EntityIUserWeaponNote
    {
        [Key(0)] // RVA: 0x1DEB34C Offset: 0x1DEB34C VA: 0x1DEB34C
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DEB38C Offset: 0x1DEB38C VA: 0x1DEB38C
        public int WeaponId { get; set; }
        [Key(2)] // RVA: 0x1DEB3CC Offset: 0x1DEB3CC VA: 0x1DEB3CC
        public int MaxLevel { get; set; }
        [Key(3)] // RVA: 0x1DEB3E0 Offset: 0x1DEB3E0 VA: 0x1DEB3E0
        public int MaxLimitBreakCount { get; set; }
        [Key(4)] // RVA: 0x1DEB3F4 Offset: 0x1DEB3F4 VA: 0x1DEB3F4
        public long FirstAcquisitionDatetime { get; set; }
        [Key(5)] // RVA: 0x1DEB408 Offset: 0x1DEB408 VA: 0x1DEB408
        public long LatestVersion { get; set; }
	}
}
