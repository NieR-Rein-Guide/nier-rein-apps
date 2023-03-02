using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_big_hunt_phase_group")]
    public class EntityMBattleBigHuntPhaseGroup
    {
        [Key(0)]
        public int BattleBigHuntPhaseGroupId { get; set; } // 0x10
        [Key(1)]
        public int BattleBigHuntPhaseGroupOrder { get; set; } // 0x14
        [Key(2)]
        public int KnockDownDamageThresholdGroupId { get; set; } // 0x18
        [Key(3)]
        public int NormalPhaseFrameCount { get; set; } // 0x1C
    }
}