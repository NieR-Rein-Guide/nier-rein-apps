using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMTipBackgroundAsset))]
public class EntityMTipBackgroundAsset
{
    [Key(0)]
    public int TipBackgroundAssetId { get; set; }

    [Key(1)]
    public string BackgroundAssetName { get; set; }
}
