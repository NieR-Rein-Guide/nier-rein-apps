using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestSceneChoiceEffect))]
public class EntityMQuestSceneChoiceEffect
{
    [Key(0)]
    public int QuestSceneChoiceEffectId { get; set; }

    [Key(1)]
    public int QuestSceneChoiceGroupingId { get; set; }

    [Key(2)]
    public int QuestSceneChoiceCostumeEffectGroupId { get; set; }

    [Key(3)]
    public int QuestSceneChoiceWeaponEffectGroupId { get; set; }
}
