using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_weapon_skill")]
    public class EntityIUserWeaponSkill
    {
        [Key(0)] // RVA: 0x1DEB41C Offset: 0x1DEB41C VA: 0x1DEB41C
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DEB45C Offset: 0x1DEB45C VA: 0x1DEB45C
        public string UserWeaponUuid { get; set; }
        [Key(2)] // RVA: 0x1DEB49C Offset: 0x1DEB49C VA: 0x1DEB49C
        public int SlotNumber { get; set; }
        [Key(3)] // RVA: 0x1DEB4DC Offset: 0x1DEB4DC VA: 0x1DEB4DC
        public int Level { get; set; }
        [Key(4)] // RVA: 0x1DEB4F0 Offset: 0x1DEB4F0 VA: 0x1DEB4F0
        public long LatestVersion { get; set; }
	}
}
