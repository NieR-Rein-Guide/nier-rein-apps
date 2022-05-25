using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_weapon")]
    public class EntityIUserWeapon
    {
        [Key(0)] // RVA: 0x1DEB158 Offset: 0x1DEB158 VA: 0x1DEB158
        public long UserId { get; set; }    // 0x10
        [Key(1)] // RVA: 0x1DEB198 Offset: 0x1DEB198 VA: 0x1DEB198
        public string UserWeaponUuid { get; set; }  // 0x18
        [Key(2)] // RVA: 0x1DEB1D8 Offset: 0x1DEB1D8 VA: 0x1DEB1D8
        public int WeaponId { get; set; }   // 0x20
        [Key(3)] // RVA: 0x1DEB1EC Offset: 0x1DEB1EC VA: 0x1DEB1EC
        public int Level { get; set; }  // 0x24
        [Key(4)] // RVA: 0x1DEB200 Offset: 0x1DEB200 VA: 0x1DEB200
        public int Exp { get; set; }    // 0x28
        [Key(5)] // RVA: 0x1DEB214 Offset: 0x1DEB214 VA: 0x1DEB214
        public int LimitBreakCount { get; set; }    // 0x2C
        [Key(6)] // RVA: 0x1DEB228 Offset: 0x1DEB228 VA: 0x1DEB228
        public bool IsProtected { get; set; }
        [Key(7)] // RVA: 0x1DEB23C Offset: 0x1DEB23C VA: 0x1DEB23C
        public long AcquisitionDatetime { get; set; }   // 0x38
        [Key(8)] // RVA: 0x1DEB250 Offset: 0x1DEB250 VA: 0x1DEB250
        public long LatestVersion { get; set; }
	}
}
