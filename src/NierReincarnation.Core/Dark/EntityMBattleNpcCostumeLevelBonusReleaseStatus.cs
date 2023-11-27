using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcCostumeLevelBonusReleaseStatus))]
public class EntityMBattleNpcCostumeLevelBonusReleaseStatus
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int CostumeId { get; set; }

    [Key(2)]
    public int LastReleasedBonusLevel { get; set; }

    [Key(3)]
    public int ConfirmedBonusLevel { get; set; }
}
