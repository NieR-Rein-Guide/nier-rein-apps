using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_character_costume_level_bonus")]
    public class EntityMBattleNpcCharacterCostumeLevelBonus
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10
        [Key(1)]
        public int CharacterId { get; set; } // 0x18
        [Key(2)]
        public int StatusCalculationType { get; set; } // 0x1C
        [Key(3)]
        public int Hp { get; set; } // 0x20
        [Key(4)]
        public int Attack { get; set; } // 0x24
        [Key(5)]
        public int Vitality { get; set; } // 0x28
        [Key(6)]
        public int Agility { get; set; } // 0x2C
        [Key(7)]
        public int CriticalRatio { get; set; } // 0x30
        [Key(8)]
        public int CriticalAttack { get; set; } // 0x34
    }
}