using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMEventQuestLabyrinthQuestEffectDescriptionFree))]
public class EntityMEventQuestLabyrinthQuestEffectDescriptionFree
{
    [Key(0)]
    public int EventQuestLabyrinthQuestEffectDescriptionId { get; set; }

    [Key(1)]
    public int AssetId { get; set; }
}
