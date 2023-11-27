using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserPossessionAutoConvert))]
public class EntityIUserPossessionAutoConvert
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public PossessionType PossessionType { get; set; }

    [Key(2)]
    public int PossessionId { get; set; }

    [Key(3)]
    public int FromCount { get; set; }

    [Key(4)]
    public PossessionType ToPossessionType { get; set; }

    [Key(5)]
    public int ToPossessionId { get; set; }

    [Key(6)]
    public int ToCount { get; set; }

    [Key(7)]
    public long ConvertDatetime { get; set; }

    [Key(8)]
    public long LatestVersion { get; set; }
}
