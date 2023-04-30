using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_weapon")]
    public class EntityIUserWeapon
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public string UserWeaponUuid { get; set; } // 0x18

        [Key(2)]
        public int WeaponId { get; set; } // 0x20

        [Key(3)]
        public int Level { get; set; } // 0x24

        [Key(4)]
        public int Exp { get; set; } // 0x28

        [Key(5)]
        public int LimitBreakCount { get; set; } // 0x2C

        [Key(6)]
        public bool IsProtected { get; set; } // 0x30

        [Key(7)]
        public long AcquisitionDatetime { get; set; } // 0x38

        [Key(8)]
        public long LatestVersion { get; set; } // 0x40
    }
}
