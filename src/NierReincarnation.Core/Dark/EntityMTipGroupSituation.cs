using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMTipGroupSituation))]
public class EntityMTipGroupSituation
{
    [Key(0)]
    public TipSituationType TipSituationType { get; set; }

    [Key(1)]
    public int TipGroupId { get; set; }

    [Key(2)]
    public int Weight { get; set; }

    [Key(3)]
    public int TargetId { get; set; }
}
