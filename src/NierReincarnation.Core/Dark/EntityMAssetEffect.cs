using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMAssetEffect))]
public class EntityMAssetEffect
{
    [Key(0)]
    public int AssetEffectId { get; set; }

    [Key(1)]
    public string AssetPath { get; set; }
}
