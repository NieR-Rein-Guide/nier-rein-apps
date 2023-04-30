using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_awaken_status_up_group")]
    public class EntityMWeaponAwakenStatusUpGroup
    {
        [Key(0)]
        public int WeaponAwakenStatusUpGroupId { get; set; } // 0x10

        [Key(1)]
        public StatusKindType StatusKindType { get; set; } // 0x14

        [Key(2)]
        public StatusCalculationType StatusCalculationType { get; set; } // 0x18

        [Key(3)]
        public int EffectValue { get; set; } // 0x1C
    }
}
