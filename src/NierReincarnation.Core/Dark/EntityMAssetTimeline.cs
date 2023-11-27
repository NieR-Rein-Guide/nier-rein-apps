using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMAssetTimeline))]
public class EntityMAssetTimeline
{
    [Key(0)]
    public int AssetTimelineId { get; set; }

    [Key(1)]
    public string AssetPath { get; set; }
}
