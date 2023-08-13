using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_important_item_effect_drop_rate")]
public class EntityMImportantItemEffectDropRate
{
    [Key(0)]
    public int ImportantItemEffectDropRateId { get; set; }

    [Key(1)]
    public int RatePermil { get; set; }

    [Key(2)]
    public int ImportantItemEffectTargetQuestGroupId { get; set; }

    [Key(3)]
    public int ImportantItemEffectTargetItemGroupId { get; set; }
}
