using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_weapon_note")]
    public class EntityIUserWeaponNote
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int WeaponId { get; set; } // 0x18

        [Key(2)]
        public int MaxLevel { get; set; } // 0x1C

        [Key(3)]
        public int MaxLimitBreakCount { get; set; } // 0x20

        [Key(4)]
        public long FirstAcquisitionDatetime { get; set; } // 0x28

        [Key(5)]
        public long LatestVersion { get; set; } // 0x30
    }
}
