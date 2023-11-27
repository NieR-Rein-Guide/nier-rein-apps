using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMAssetTurnbattlePrefab))]
public class EntityMAssetTurnbattlePrefab
{
    [Key(0)]
    public int AssetTurnbattlePrefabId { get; set; }

    [Key(1)]
    public string AssetPath { get; set; }
}
