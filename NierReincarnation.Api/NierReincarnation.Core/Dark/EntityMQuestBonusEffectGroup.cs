using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_bonus_effect_group")]
public class EntityMQuestBonusEffectGroup
{
    [Key(0)]
    public int QuestBonusEffectGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public QuestBonusType QuestBonusType { get; set; }

    [Key(3)]
    public int QuestBonusEffectId { get; set; }
}
