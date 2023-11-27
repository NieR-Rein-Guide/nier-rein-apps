using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMImportantItemEffectDropCount))]
public class EntityMImportantItemEffectDropCount
{
    [Key(0)]
    public int ImportantItemEffectDropCountId { get; set; }

    [Key(1)]
    public int CountPermil { get; set; }

    [Key(2)]
    public int ImportantItemEffectTargetQuestGroupId { get; set; }

    [Key(3)]
    public int ImportantItemEffectTargetItemGroupId { get; set; }
}
