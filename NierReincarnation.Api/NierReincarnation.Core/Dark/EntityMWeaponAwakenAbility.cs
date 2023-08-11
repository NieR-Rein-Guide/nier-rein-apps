using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_awaken_ability")]
    public class EntityMWeaponAwakenAbility
    {
        [Key(0)]
        public int WeaponAwakenAbilityId { get; set; }

        [Key(1)]
        public int AbilityId { get; set; }

        [Key(2)]
        public int AbilityLevel { get; set; }
    }
}
