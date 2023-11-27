using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserCostumeLotteryEffectPending))]
public class EntityIUserCostumeLotteryEffectPending
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public string UserCostumeUuid { get; set; }

    [Key(2)]
    public int SlotNumber { get; set; }

    [Key(3)]
    public int OddsNumber { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
