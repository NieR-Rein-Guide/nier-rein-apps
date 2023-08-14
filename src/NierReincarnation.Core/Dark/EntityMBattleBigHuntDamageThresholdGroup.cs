using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_big_hunt_damage_threshold_group")]
public class EntityMBattleBigHuntDamageThresholdGroup
{
    [Key(0)]
    public int KnockDownDamageThresholdGroupId { get; set; }

    [Key(1)]
    public int KnockDownDamageThresholdGroupOrder { get; set; }

    [Key(2)]
    public int KnockDownCumulativeDamageThreshold { get; set; }

    [Key(3)]
    public bool IsKnockDown { get; set; }

    [Key(4)]
    public int KnockDownDurationFrameCount { get; set; }

    [Key(5)]
    public int DamageRatio { get; set; }
}
