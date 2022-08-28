using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_parts_preset")]
    public class EntityMBattleNpcPartsPreset
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10
        [Key(1)]
        public int BattleNpcPartsPresetNumber { get; set; } // 0x18
        [Key(2)]
        public string BattleNpcPartsUuid01 { get; set; } // 0x20
        [Key(3)]
        public string BattleNpcPartsUuid02 { get; set; } // 0x28
        [Key(4)]
        public string BattleNpcPartsUuid03 { get; set; } // 0x30
        [Key(5)]
        public string Name { get; set; } // 0x38
        [Key(6)]
        public int BattleNpcPartsPresetTagNumber { get; set; } // 0x40
    }
}