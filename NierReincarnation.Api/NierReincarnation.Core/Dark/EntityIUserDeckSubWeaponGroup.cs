using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_deck_sub_weapon_group")]
    public class EntityIUserDeckSubWeaponGroup
    {
        [Key(0)] // RVA: 0x1DE8B88 Offset: 0x1DE8B88 VA: 0x1DE8B88
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE8BC8 Offset: 0x1DE8BC8 VA: 0x1DE8BC8
        public string UserDeckCharacterUuid { get; set; }
        [Key(2)] // RVA: 0x1DE8C08 Offset: 0x1DE8C08 VA: 0x1DE8C08
        public string UserWeaponUuid { get; set; }
        [Key(3)] // RVA: 0x1DE8C48 Offset: 0x1DE8C48 VA: 0x1DE8C48
        public int SortOrder { get; set; }
        [Key(4)] // RVA: 0x1DE8C5C Offset: 0x1DE8C5C VA: 0x1DE8C5C
        public long LatestVersion { get; set; }
	}
}
