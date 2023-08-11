using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_asset_data_setting")]
public class EntityMAssetDataSetting
{
    [Key(0)]
    public int AssetDataSettingId { get; set; }

    [Key(1)]
    public string AssetPath { get; set; }
}
