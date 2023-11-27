using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMEventQuestLabyrinthQuestEffectDescriptionAbility))]
public class EntityMEventQuestLabyrinthQuestEffectDescriptionAbility
{
    [Key(0)]
    public int EventQuestLabyrinthQuestEffectDescriptionId { get; set; }

    [Key(1)]
    public int AbilityId { get; set; }

    [Key(2)]
    public int AbilityLevel { get; set; }
}
