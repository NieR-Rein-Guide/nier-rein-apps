using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserCostumeLotteryEffectAbility))]
public class EntityIUserCostumeLotteryEffectAbility
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public string UserCostumeUuid { get; set; }

    [Key(2)]
    public int SlotNumber { get; set; }

    [Key(3)]
    public int AbilityId { get; set; }

    [Key(4)]
    public int AbilityLevel { get; set; }

    [Key(5)]
    public long LatestVersion { get; set; }
}
