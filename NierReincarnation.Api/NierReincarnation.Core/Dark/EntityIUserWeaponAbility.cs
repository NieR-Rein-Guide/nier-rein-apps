using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_weapon_ability")]
    public class EntityIUserWeaponAbility
    {
        [Key(0)] // RVA: 0x1DEB264 Offset: 0x1DEB264 VA: 0x1DEB264
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DEB2A4 Offset: 0x1DEB2A4 VA: 0x1DEB2A4
        public string UserWeaponUuid { get; set; }
        [Key(2)] // RVA: 0x1DEB2E4 Offset: 0x1DEB2E4 VA: 0x1DEB2E4
        public int SlotNumber { get; set; }
        [Key(3)] // RVA: 0x1DEB324 Offset: 0x1DEB324 VA: 0x1DEB324
        public int Level { get; set; }
        [Key(4)] // RVA: 0x1DEB338 Offset: 0x1DEB338 VA: 0x1DEB338
        public long LatestVersion { get; set; }
	}
}
