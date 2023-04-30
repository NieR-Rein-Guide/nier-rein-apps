using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_awaken")]
    public class EntityMWeaponAwaken
    {
        [Key(0)]
        public int WeaponId { get; set; } // 0x10

        [Key(1)]
        public int WeaponAwakenEffectGroupId { get; set; } // 0x14

        [Key(2)]
        public int WeaponAwakenMaterialGroupId { get; set; } // 0x18

        [Key(3)]
        public int ConsumeGold { get; set; } // 0x1C

        [Key(4)]
        public int LevelLimitUp { get; set; } // 0x20
    }
}
