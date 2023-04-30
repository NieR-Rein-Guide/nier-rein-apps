using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_big_hunt_damage_threshold_group")]
    public class EntityMBattleBigHuntDamageThresholdGroup
    {
        [Key(0)]
        public int KnockDownDamageThresholdGroupId { get; set; } // 0x10

        [Key(1)]
        public int KnockDownDamageThresholdGroupOrder { get; set; } // 0x14

        [Key(2)]
        public int KnockDownCumulativeDamageThreshold { get; set; } // 0x18

        [Key(3)]
        public bool IsKnockDown { get; set; } // 0x1C

        [Key(4)]
        public int KnockDownDurationFrameCount { get; set; } // 0x20

        [Key(5)]
        public int DamageRatio { get; set; } // 0x24
    }
}
