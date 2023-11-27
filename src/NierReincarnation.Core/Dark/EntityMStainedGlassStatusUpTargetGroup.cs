using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMStainedGlassStatusUpTargetGroup))]
public class EntityMStainedGlassStatusUpTargetGroup
{
    [Key(0)]
    public int StainedGlassStatusUpTargetGroupId { get; set; }

    [Key(1)]
    public int GroupIndex { get; set; }

    [Key(2)]
    public StainedGlassStatusUpTargetType StatusUpTargetType { get; set; }

    [Key(3)]
    public int TargetValue { get; set; }
}
