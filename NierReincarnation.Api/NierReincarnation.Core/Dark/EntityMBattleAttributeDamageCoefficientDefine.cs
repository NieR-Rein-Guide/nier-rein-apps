using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_attribute_damage_coefficient_define")]
    public class EntityMBattleAttributeDamageCoefficientDefine
    {
        [Key(0)]
        public BattleSchemeType BattleSchemeType { get; set; } // 0x10

        [Key(1)]
        public int PlayerAttributeDamageCoefficientGroupId { get; set; } // 0x14

        [Key(2)]
        public int NpcAttributeDamageCoefficientGroupId { get; set; } // 0x18
    }
}
