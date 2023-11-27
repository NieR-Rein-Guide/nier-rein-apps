using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleBigHuntPhaseGroup))]
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
