using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_big_hunt")]
    public class EntityMBattleBigHunt
    {
        [Key(0)]
        public int BattleGroupId { get; set; } // 0x10
        [Key(1)]
        public int BattleBigHuntPhaseGroupId { get; set; } // 0x14
        [Key(2)]
        public int KnockDownGaugeValueConfigGroupId { get; set; } // 0x18
    }
}