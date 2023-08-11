using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_gacha_medal")]
public class EntityMGachaMedal
{
    [Key(0)]
    public int GachaMedalId { get; set; }

    [Key(1)]
    public int CeilingCount { get; set; }

    [Key(2)]
    public int ConsumableItemId { get; set; }

    [Key(3)]
    public int ShopTransitionGachaId { get; set; }

    [Key(4)]
    public long AutoConvertDatetime { get; set; }

    [Key(5)]
    public int ConversionRate { get; set; }
}
