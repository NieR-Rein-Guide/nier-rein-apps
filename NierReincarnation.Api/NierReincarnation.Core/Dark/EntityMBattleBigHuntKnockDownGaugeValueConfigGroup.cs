using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_big_hunt_knock_down_gauge_value_config_group")]
    public class EntityMBattleBigHuntKnockDownGaugeValueConfigGroup
    {
        [Key(0)]
        public int KnockDownGaugeValueConfigGroupId { get; set; } // 0x10

        [Key(1)]
        public int ActiveSkillHitCount { get; set; } // 0x14

        [Key(2)]
        public int DamageValueLowerLimit { get; set; } // 0x18

        [Key(3)]
        public int GaugeValueLowerLimit { get; set; } // 0x1C

        [Key(4)]
        public int CorrectionRatioPermil { get; set; } // 0x20
    }
}
