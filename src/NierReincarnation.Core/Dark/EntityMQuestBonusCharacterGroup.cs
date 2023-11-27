using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestBonusCharacterGroup))]
public class EntityMQuestBonusCharacterGroup
{
    [Key(0)]
    public int QuestBonusCharacterGroupId { get; set; }

    [Key(1)]
    public int CharacterId { get; set; }

    [Key(2)]
    public int QuestBonusEffectGroupId { get; set; }

    [Key(3)]
    public int QuestBonusTermGroupId { get; set; }
}
