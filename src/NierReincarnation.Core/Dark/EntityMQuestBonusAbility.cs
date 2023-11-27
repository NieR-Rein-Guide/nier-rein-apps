using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestBonusAbility))]
public class EntityMQuestBonusAbility
{
    [Key(0)]
    public int QuestBonusEffectId { get; set; }

    [Key(1)]
    public int AbilityId { get; set; }

    [Key(2)]
    public int Level { get; set; }
}
