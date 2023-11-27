using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMDeckEntrustCoefficientPartsSeriesBonusCount))]
public class EntityMDeckEntrustCoefficientPartsSeriesBonusCount
{
    [Key(0)]
    public int PartsSeriesBonusCount { get; set; }

    [Key(1)]
    public int CoefficientPermil { get; set; }
}
