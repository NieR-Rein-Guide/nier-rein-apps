using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_enhanced")]
    public class EntityMWeaponEnhanced
    {
        [Key(0)] // RVA: 0x1DFA768 Offset: 0x1DFA768 VA: 0x1DFA768
        public int WeaponEnhancedId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DFA7A8 Offset: 0x1DFA7A8 VA: 0x1DFA7A8
        public int WeaponId { get; set; }// 0x14

        [Key(2)] // RVA: 0x1DFA7BC Offset: 0x1DFA7BC VA: 0x1DFA7BC
        public int Level { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DFA7D0 Offset: 0x1DFA7D0 VA: 0x1DFA7D0
        public int LimitBreakCount { get; set; } // 0x1C
    }
}
