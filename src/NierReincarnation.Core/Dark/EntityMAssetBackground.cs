using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_asset_background")]
public class EntityMAssetBackground
{
    [Key(0)]
    public int AssetBackgroundId { get; set; }

    [Key(1)]
    public string BackgroundAssetPath { get; set; }

    [Key(2)]
    public string GlobalEventMapAssetPath { get; set; }
}
