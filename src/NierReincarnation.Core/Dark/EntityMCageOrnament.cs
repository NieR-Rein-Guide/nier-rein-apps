using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCageOrnament))]
public class EntityMCageOrnament
{
    [Key(0)]
    public int CageOrnamentId { get; set; }

    [Key(1)]
    public long StartDatetime { get; set; }

    [Key(2)]
    public long EndDatetime { get; set; }

    [Key(3)]
    public int CageOrnamentRewardId { get; set; }
}
