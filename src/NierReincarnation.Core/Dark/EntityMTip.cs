using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_tip")]
public class EntityMTip
{
    [Key(0)]
    public int TipId { get; set; }

    [Key(1)]
    public int TitleTipTextId { get; set; }

    [Key(2)]
    public int ContentTipTextId { get; set; }

    [Key(3)]
    public int TipDisplayConditionGroupId { get; set; }

    [Key(4)]
    public string BackgroundAssetName { get; set; }

    [Key(5)]
    public long StartDatetime { get; set; }

    [Key(6)]
    public long EndDatetime { get; set; }
}
