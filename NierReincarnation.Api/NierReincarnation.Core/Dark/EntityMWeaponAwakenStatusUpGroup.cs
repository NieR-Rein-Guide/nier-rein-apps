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
        public int WeaponAwakenStatusUpGroupId { get; set; }

        [Key(1)]
        public StatusKindType StatusKindType { get; set; }

        [Key(2)]
        public StatusCalculationType StatusCalculationType { get; set; }

        [Key(3)]
        public int EffectValue { get; set; }
    }
}
