using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcCostumeLevelBonusReevaluate))]
public class EntityMBattleNpcCostumeLevelBonusReevaluate
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public long LastReevaluateDatetime { get; set; }
}
