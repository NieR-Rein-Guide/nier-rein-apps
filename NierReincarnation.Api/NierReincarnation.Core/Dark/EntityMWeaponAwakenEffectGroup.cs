using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_awaken_effect_group")]
    public class EntityMWeaponAwakenEffectGroup
    {
        [Key(0)]
        public int WeaponAwakenEffectGroupId { get; set; } // 0x10

        [Key(1)]
        public int WeaponAwakenEffectType { get; set; } // 0x14

        [Key(2)]
        public int WeaponAwakenEffectId { get; set; } // 0x18
    }
}
