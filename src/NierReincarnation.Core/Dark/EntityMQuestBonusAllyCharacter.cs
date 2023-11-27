using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestBonusAllyCharacter))]
public class EntityMQuestBonusAllyCharacter
{
    [Key(0)]
    public int QuestBonusAllyCharacterId { get; set; }

    [Key(1)]
    public int QuestBonusEffectGroupId { get; set; }

    [Key(2)]
    public int QuestBonusTermGroupId { get; set; }
}
