using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_big_hunt_phase_group")]
    public class EntityMBattleBigHuntPhaseGroup
    {
        [Key(0)]
        public int BattleBigHuntPhaseGroupId { get; set; }

        [Key(1)]
        public int BattleBigHuntPhaseGroupOrder { get; set; }

        [Key(2)]
        public int KnockDownDamageThresholdGroupId { get; set; }

        [Key(3)]
        public int NormalPhaseFrameCount { get; set; }
    }
}
