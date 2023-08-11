using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_asset_calculator")]
public class EntityMAssetCalculator
{
    [Key(0)]
    public int AssetCalculatorId { get; set; }

    [Key(1)]
    public int UseCalculatorType { get; set; }

    [Key(2)]
    public string AssetPath { get; set; }
}
