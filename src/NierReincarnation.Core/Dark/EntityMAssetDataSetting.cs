using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMAssetDataSetting))]
public class EntityMAssetDataSetting
{
    [Key(0)]
    public int AssetDataSettingId { get; set; }

    [Key(1)]
    public string AssetPath { get; set; }
}
