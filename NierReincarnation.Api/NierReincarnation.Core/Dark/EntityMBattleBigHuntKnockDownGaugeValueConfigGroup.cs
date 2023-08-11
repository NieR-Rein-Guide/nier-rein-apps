using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_big_hunt_knock_down_gauge_value_config_group")]
public class EntityMBattleBigHuntKnockDownGaugeValueConfigGroup
{
    [Key(0)]
    public int KnockDownGaugeValueConfigGroupId { get; set; }

    [Key(1)]
    public int ActiveSkillHitCount { get; set; }

    [Key(2)]
    public int DamageValueLowerLimit { get; set; }

    [Key(3)]
    public int GaugeValueLowerLimit { get; set; }

    [Key(4)]
    public int CorrectionRatioPermil { get; set; }
}
