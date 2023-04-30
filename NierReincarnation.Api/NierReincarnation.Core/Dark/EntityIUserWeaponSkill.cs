using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_weapon_skill")]
    public class EntityIUserWeaponSkill
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public string UserWeaponUuid { get; set; } // 0x18

        [Key(2)]
        public int SlotNumber { get; set; } // 0x20

        [Key(3)]
        public int Level { get; set; } // 0x24

        [Key(4)]
        public long LatestVersion { get; set; } // 0x28
    }
}
