using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_deck_sub_weapon_group")]
    public class EntityIUserDeckSubWeaponGroup
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public string UserDeckCharacterUuid { get; set; } // 0x18

        [Key(2)]
        public string UserWeaponUuid { get; set; } // 0x20

        [Key(3)]
        public int SortOrder { get; set; } // 0x28

        [Key(4)]
        public long LatestVersion { get; set; } // 0x30
    }
}
