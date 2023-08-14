using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_asset_grade_icon")]
public class EntityMAssetGradeIcon
{
    [Key(0)]
    public int AssetGradeIconId { get; set; }

    [Key(1)]
    public int AssetId { get; set; }

    [Key(2)]
    public int Level { get; set; }

    [Key(3)]
    public int SeAssetId { get; set; }
}
