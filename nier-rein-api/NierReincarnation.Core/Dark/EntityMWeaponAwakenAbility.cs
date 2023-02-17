using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_awaken_ability")]
    public class EntityMWeaponAwakenAbility
    {
        [Key(0)]
        public int WeaponAwakenAbilityId { get; set; } // 0x10
        [Key(1)]
        public int AbilityId { get; set; } // 0x14
        [Key(2)]
        public int AbilityLevel { get; set; } // 0x18
    }
}