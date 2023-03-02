using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_enhanced_ability")]
    public class EntityMWeaponEnhancedAbility
    {
        [Key(0)]
        public int WeaponEnhancedId { get; set; } // 0x10
        [Key(1)]
        public int AbilityId { get; set; } // 0x14
        [Key(2)]
        public int Level { get; set; } // 0x18
    }
}