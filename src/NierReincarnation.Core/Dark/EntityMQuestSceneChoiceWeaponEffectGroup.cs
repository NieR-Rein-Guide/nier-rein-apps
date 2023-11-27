using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestSceneChoiceWeaponEffectGroup))]
public class EntityMQuestSceneChoiceWeaponEffectGroup
{
    [Key(0)]
    public int QuestSceneChoiceWeaponEffectGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int WeaponId { get; set; }
}
