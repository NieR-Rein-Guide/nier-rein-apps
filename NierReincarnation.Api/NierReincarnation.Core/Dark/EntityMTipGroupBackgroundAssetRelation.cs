using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_tip_group_background_asset_relation")]
public class EntityMTipGroupBackgroundAssetRelation
{
    [Key(0)]
    public int TipGroupId { get; set; }

    [Key(1)]
    public int TipBackgroundAssetId { get; set; }

    [Key(2)]
    public int TipDisplayConditionGroupId { get; set; }
}
