using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMPvpReward))]
public class EntityMPvpReward
{
    [Key(0)]
    public int PvpRewardId { get; set; }

    [Key(1)]
    public PossessionType PossessionType { get; set; }

    [Key(2)]
    public int PossessionId { get; set; }

    [Key(3)]
    public int Count { get; set; }
}
