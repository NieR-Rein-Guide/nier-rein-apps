using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_enhanced_ability")]
    public class EntityMWeaponEnhancedAbility
    {
        [Key(0)]
        public int WeaponEnhancedId { get; set; }

        [Key(1)]
        public int AbilityId { get; set; }

        [Key(2)]
        public int Level { get; set; }
    }
}
