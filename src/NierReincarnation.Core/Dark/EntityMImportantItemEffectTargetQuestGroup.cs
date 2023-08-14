using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_important_item_effect_target_quest_group")]
public class EntityMImportantItemEffectTargetQuestGroup
{
    [Key(0)]
    public int ImportantItemEffectTargetQuestGroupId { get; set; }

    [Key(1)]
    public int TargetIndex { get; set; }

    [Key(2)]
    public ImportantItemEffectTargetQuestGroupType ImportantItemEffectTargetQuestGroupType { get; set; }

    [Key(3)]
    public int TargetValue { get; set; }
}