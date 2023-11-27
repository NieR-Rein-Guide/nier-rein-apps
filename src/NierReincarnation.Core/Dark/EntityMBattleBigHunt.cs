using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleBigHunt))]
public class EntityMBattleBigHunt
{
    [Key(0)]
    public int BattleGroupId { get; set; }

    [Key(1)]
    public int BattleBigHuntPhaseGroupId { get; set; }

    [Key(2)]
    public int KnockDownGaugeValueConfigGroupId { get; set; }
}
